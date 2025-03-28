using UnityEngine;

namespace Assets.Scripts.Service
{
    public class SaveServer
    {
        private Setting setting;
        public SaveServer(Setting setting)
        {
            this.setting = setting;
        }

        public virtual void Save()
        {
            PlayerPrefs.SetFloat("Volume", setting.Volume);
            PlayerPrefs.Save();
        }

        public virtual bool Load()
        {
            if (!PlayerPrefs.HasKey("Volume"))
                return false;

            var volume = PlayerPrefs.GetFloat("Volume");
            setting.Volume = volume;
            return true;
        }
    }
}