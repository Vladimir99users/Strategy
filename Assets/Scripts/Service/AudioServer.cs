using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Service
{
    public class AudioServer : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup mixerMusic;
        [SerializeField] private AudioSource sourceMusic;

        private const float VOLUME_MAX = 0f;
        private const float VOLUME_MIN = -80f;
        private const float OFFSET = VOLUME_MIN - VOLUME_MAX;

        public const string MUSIC_NAME_MIXER = "MusicVolume";
        public void Initialize(Setting setting, IMusicChanged musicChanged)
        {
            musicChanged.OnChangeMusicVolume += SetMusicAudioValue;
            SetMusicAudioValue(setting.Volume);
            sourceMusic.Play();
        }

        public void SetMusicAudioValue(float value)
        {
            var musicValue = VOLUME_MIN - (OFFSET * value) / 100f;
            mixerMusic.audioMixer.SetFloat(MUSIC_NAME_MIXER, musicValue);
        }

    }
}