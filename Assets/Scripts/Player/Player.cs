using Assets.Scripts.Building;
using Assets.Scripts.Building.Item;
using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Player : MonoBehaviour, IDataCollection
    {
        [SerializeField] private Animator animator;
        private NavMeshAgent agent;
        private IPlayerController controller;
        private Coroutine coroutine;
        private Building.Building targetBuilding;
        public event System.Action<Item> OnCollectItem;
        public void Initialize(IPlayerController controller)
        {
            this.controller = controller;
            agent = GetComponent<NavMeshAgent>();
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
            controller.OnPlayerMoved += Move;
        }

        private void Move(Vector2 obj)
        {
            var ray = Camera.main.ScreenPointToRay(obj);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var endPoint = hit.point;

                if (coroutine is not null)
                    StopCoroutine(coroutine);

                if (hit.collider.gameObject.TryGetComponent(out Building.Building building))
                {
                    targetBuilding = building;
                    endPoint = targetBuilding.PointToGrab.position;
                    coroutine = StartCoroutine(CollectResources(targetBuilding));
                }

                agent.SetDestination(endPoint);
            }
        }

        private void LateUpdate()
        {
            animator.SetFloat("Speed", agent.hasPath ? 1 : 0);
        }

        private IEnumerator CollectResources(Building.Building building)
        {
            while (Vector3.Distance(transform.position, building.PointToGrab.position) > 1f)
                yield return null;

            transform.LookAt(building.transform);
            animator.SetTrigger("IsGrabItem");
        }

        private void OnGrab()
        {
            if (targetBuilding is IProduce<Item> produce)
            {
                var item = produce.GetItem();
                Debug.Log($"Collect data = {item.Type} = {item.Amount}");
                OnCollectItem?.Invoke(item);
            }
        }


    }
}
