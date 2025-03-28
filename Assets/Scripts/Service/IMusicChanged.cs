using System;

namespace Assets.Scripts.Service
{
    public interface IMusicChanged
    {
        public event Action<float> OnChangeMusicVolume;
    }
}