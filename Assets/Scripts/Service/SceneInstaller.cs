using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public class SceneInstaller : MonoBehaviour
    {
        [SerializeField] private TimerService timerService;
        [SerializeField] private SpawnPlayerService spawnPlayerService;
        [SerializeField] private InputService inputService;
        [SerializeField] private CameraService cameraService;

        [SerializeField] private List<Building.ProductionBuild> buildings;
        private void Awake()
            => OnAwake();
        protected virtual void OnAwake()
        {
            timerService.Initialize();
            inputService.Initialize();
        }

        private void Start()
            => OnStart();

        protected virtual void OnStart()
        {
            spawnPlayerService.Initialize(inputService);
            buildings.ForEach(x => x.Initialize(timerService));
            cameraService.Initialize(inputService);
        }

    }
}
