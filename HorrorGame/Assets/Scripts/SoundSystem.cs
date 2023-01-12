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
        private AudioSource BGaud;
        private AudioSource BGaud2;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
            BGaud = GameObject.Find("PlayerCapsule").GetComponent<AudioSource>();
            BGaud2 = GameObject.Find("BGM_PLAYER").GetComponent<AudioSource>();
        }

        public void playSound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
            print("����");
        }

        public void closeBGM()
        {
            BGaud.Stop();
            BGaud2.Stop();
        }

    }
}


