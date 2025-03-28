using Assets.Scripts.Building.Item;
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
        [SerializeField] private DataService dataService;
        [SerializeField] private HUD hud;
        [SerializeField] private AudioServer audioServer;
        [SerializeField] private SettingMenu settingMenu;

        [SerializeField] private List<Building.ProductionBuild> buildings;
        [SerializeField] private List<ItemConfiguration> itemConfigurations;

        private SaveServer saveServer;
        private Setting setting;
        private void Awake()
            => OnAwake();
        protected virtual void OnAwake()
        {
            setting = new Setting();
            saveServer = new SaveServer(setting);
            if (!saveServer.Load())
            {
                Debug.Log("Data is not loaded");
            }
            settingMenu.Initialize(setting);
            timerService.Initialize();
            inputService.Initialize();
        }

        private void Start()
            => OnStart();

        protected virtual void OnStart()
        {
            audioServer.Initialize(setting, settingMenu);
            spawnPlayerService.Initialize(inputService);
            buildings.ForEach(x => x.Initialize(timerService));
            cameraService.Initialize(inputService);
            dataService.Initialize(itemConfigurations, spawnPlayerService.Player);
            hud.Initialize(dataService, itemConfigurations);
        }

        private void OnDisable()
        {
            saveServer.Save();
        }

    }
}
