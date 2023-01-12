using UnityEngine;

namespace Misun
{
    /// <summary>
    /// ���Ĩt�ΡA�������Ĩƥ�P����
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
            print("����");
        }

    }
}


