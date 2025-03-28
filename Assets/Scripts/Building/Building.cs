using UnityEngine;

namespace Assets.Scripts.Building
{
    public abstract class Building : MonoBehaviour
    {
        [SerializeField] private Transform pointToGrab;
        public Transform PointToGrab => pointToGrab;
    }
}
