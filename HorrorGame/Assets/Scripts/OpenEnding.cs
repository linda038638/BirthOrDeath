using UnityEngine;

namespace Misun
{
    public class OpenEnding : MonoBehaviour
    {
        [SerializeField,Header("�q���e��")]
        private GameObject gameObject;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Ending()
        {
            gameObject.SetActive(true);
        }

    }

}

