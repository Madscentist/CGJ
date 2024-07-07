using System.Collections;
using System.Collections.Generic;
using Game;
using Mmang;
using UnityEngine;

namespace Mmang
{
    public class SoundPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;
        private AudioClip _clip;

        private void Awake() => _audioSource = GetComponent<AudioSource>();

        public void Init(AudioClip clip)
        {
            _clip = clip;
            _audioSource.clip = clip;
            _audioSource.Play();
        }   
    
        private void Update()
        {
            if (!_audioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }


    public static class SoundPlayerUtil
    {
        public static SoundPlayer CreateSoundPlayer(Vector2 pos)
        {
            return GameObject.Instantiate<SoundPlayer>(GameSetting.SoundPlayerPrefab, pos, Quaternion.identity);
        }
    }
}