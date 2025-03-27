using UnityEngine;

namespace Assets.Scripts.Service
{
    public class SceneInstaller : MonoBehaviour
    {
        [SerializeField] private TimerService timerService;
        [SerializeField] private SpawnPlayerService spawnPlayerService;
        [SerializeField] private InputService inputService;
        private void Awake()
            => OnAwake();
        protected virtual void OnAwake()
        {
            timerService.Initialize();
            spawnPlayerService.Initialize();
            inputService.Initialize();
        }

        private void Start()
            => OnStart();

        protected virtual void OnStart()
        {

        }

    }
}
