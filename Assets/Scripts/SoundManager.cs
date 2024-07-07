using System.Collections;
using System.Collections.Generic;
using Mmang;
using UnityEditor;
using UnityEngine;

namespace Mmang
{


    [System.Serializable]
    public class AudioSetting
    {
        public string Name;
        public AudioClip Audio;
    }

    public class SoundManager : SingletonMono<SoundManager>
    {
        [SerializeField] private List<AudioSetting> _audioSettings = new();
        public List<AudioSetting> AudioSettings => _audioSettings;



        public AudioClip FindAudio(string name)
        {
            var setting = AudioSettings.Find(setting => setting.Name == name);
            if (setting == null)
                return null;
            return setting.Audio;
        }

        public static void PlaySound(string name, Vector2 pos)
        {
            PlaySound(Instance.FindAudio(name), pos);
        }

        public static void PlaySound(AudioClip audioClip, Vector2 pos)
        {
            var source = SoundPlayerUtil.CreateSoundPlayer(pos);
            source.Init(audioClip);
        }


#if UNITY_EDITOR
        [SerializeField]
        private List<AudioClip> _clips;

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            _audioSettings.Clear();
            foreach (var clip in _clips)
            {
                AudioSetting setting = new()
                {
                    Audio = clip,
                    Name = clip.name,
                };

                _audioSettings.Add(setting);
            }
        }
#endif
    }

}