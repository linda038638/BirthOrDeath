using UnityEngine;

namespace Misun
{
    public class OpenEnding : MonoBehaviour
    {
        [SerializeField,Header("通關畫面")]
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

