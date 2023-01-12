using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.InputSystem.Controls;

namespace Misun
{
    /// <summary>
    /// 對話系統,有打字機效果
    /// 對話完成之後才可以跳到下一步(下個對話)
    /// 對話期間限制其行動能力
    /// </summary>
    /// 
    public class DialogueSystem : MonoBehaviour
    {
        #region 資料區域
        [SerializeField, Header("打字機速度"), Range(0, 0.5f)]
        private float dialogueTntervalTime = 0.1f;
        [SerializeField, Header("對話間隔"), Range(0.1f, 2.0f)]
        private float IntervalTime = 0.1f;
        [SerializeField, Header("開頭對話")]
        private DialogueData dialogueOpening;

        //建立WFS類別的物件
        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueTntervalTime);
        private WaitForSeconds Interval => new WaitForSeconds(IntervalTime);
        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContents;
        private GameObject goToNext;
        private PlayerInput playerInput; //玩家輸入元件
        #endregion
        
        private UnityEvent onDiaogueFinish;

        #region 預處理事件
        private void Awake()
        {
            groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話者姓名").GetComponent<TextMeshProUGUI>();
            textContents = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();
            goToNext = GameObject.Find("下一步");
            goToNext.SetActive(false);
            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();
            StartDialogue(dialogueOpening);


        }
        #endregion

        /// <summary>
        /// 開始對話
        /// </summary>
        /// <param name="data">要執行對話的資料</param>
        /// <param name="_onDialogueFinish">對話後的事件，可以空值</param>
        public void StartDialogue(DialogueData data , UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;
            //Debug.Log("unable");
            StartCoroutine(TypeEffect(data)); //協程開始
            //這裡寫的東西會跟協程的東西同步進行(***所以不會等協程程式結束才執行***)
            onDiaogueFinish = _onDialogueFinish;
        }


        private IEnumerator TypeEffect(DialogueData data)
        {
            StartCoroutine(FadeGroup(true));

            textName.text = data.dialogueName;
            
            for (int i = 0; i < data.dialogueContents.Length; i++)
            {

                

                goToNext.SetActive(false);

                int letter = 0;

                textContents.text = "";
                    
                while(!Input.anyKey && letter< data.dialogueContents[i].Length-1)
                {
                    textContents.text += data.dialogueContents[i][letter];
                    letter++;
                    yield return dialogueInterval;
                    if(Input.anyKey)
                    {
                        print("press");
                    }
                }
                
                
                /* for (int j = 0; isTyping && j < data.dialogueContents[i].Length-1; j++)
                 {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        isTyping = false;
                    }
                    print("打字!："+j);
                     textContents.text += data.dialogueContents[i][j];
                     yield return dialogueInterval;

                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        isTyping = false;
                    }
                     
                 }
                */
                 


                textContents.text = data.dialogueContents[i];
                
                
                goToNext.SetActive(true);
                yield return Interval;

                while (!Input.GetKeyUp(KeyCode.Space))
                {

                    yield return null;
                }
               
            }

            StartCoroutine(FadeGroup(false));
            playerInput.enabled = true;           
            onDiaogueFinish?.Invoke();  //呼叫對話後的事件 ?.表示可以空值

        }


        #region FadeIn

        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            float fadeTime = fadeIn ? +0.1f : -0.1f;
            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += fadeTime;
                yield return new WaitForSeconds(0.04f);
            }

        }
        #endregion



    }
}
