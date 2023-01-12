using UnityEngine;

namespace Misun
{
    /// <summary>
    /// 音效系統，接收音效事件與播放
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundSystem : MonoBehaviour
    {
        private AudioSource aud;
        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        public void playSound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
            print("播放");
        }

    }
}


