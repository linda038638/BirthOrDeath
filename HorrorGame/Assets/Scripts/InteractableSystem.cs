using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Misun
{
    /// <summary>
    /// 互動系統
    /// 當玩家與物件互動時，觸發對話、事件
    /// 
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {

       
        [SerializeField, Header("對話資料")]
        private DialogueData dataDialogue;
        [SerializeField, Header("c8c8的事件")]
        private UnityEvent onc8c8Diaogue;
        [SerializeField, Header("對話結束後的事件")]
        private UnityEvent onDiaogueFinish;
        [SerializeField, Header("啟動道具")]
        private GameObject propActive;
        [SerializeField, Header("啟動後對話資料")]
        private DialogueData dataDialogueActive;
        [SerializeField, Header("啟動後對話結束後的事件")]
        private UnityEvent onDiaogueFinishAfterActive;
        private string nameTarget = "PlayerCapsule";
        static private int chatTimes = 0;
        

        private DialogueSystem dialogueSystem;
        private void Awake()
        {
            dialogueSystem = GameObject.Find("畫布對話系統").GetComponent<DialogueSystem>();
            
        }

        private void OnTriggerEnter(Collider other)
        {

            if(this.gameObject.name.Contains("c8"))
            {
                c8c8Event();
            }
            print(chatTimes);

            if(other.gameObject.name == nameTarget)
            {
                 if( 6>chatTimes && chatTimes>3 &&  this.gameObject.name.Contains("c8c8"))
                {
                    
                    dialogueSystem.StartDialogue(dataDialogueActive, onDiaogueFinishAfterActive);
                
                }else if(propActive == null || propActive.activeInHierarchy )
                {
                    
                    Debug.Log("第一階段說話");
                    dialogueSystem.StartDialogue(dataDialogue, onDiaogueFinish);
                }
                else
                {
                    Debug.Log("啟動後說話");
                    dialogueSystem.StartDialogue(dataDialogueActive, onDiaogueFinishAfterActive);
                    
                }
               
                
            }
        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
            Debug.Log("隱藏物件");
        }


        //遇到嘻巴嘻巴就做
        private void c8c8Event()
        {
            chatTimes++;
            onc8c8Diaogue.Invoke();
        }



    }

}

