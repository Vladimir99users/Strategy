using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Service
{
    public class SettingMenu : Screen, IMusicChanged
    {
        [SerializeField] private Slider volumeSlider;
        private Setting setting;
        public event Action<float> OnChangeMusicVolume;
        public void Initialize(Setting setting)
        {
            this.setting = setting;
            volumeSlider.value = setting.Volume;
            volumeSlider.onValueChanged.AddListener(ChangeValue);
        }

        private void ChangeValue(float volume)
        {
            setting.Volume = volume;
            OnChangeMusicVolume?.Invoke(setting.Volume);
        }
    }
}