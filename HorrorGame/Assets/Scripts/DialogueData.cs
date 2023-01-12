using UnityEngine;

namespace Misun
{
    /// <summary>
    /// 對話資料
    /// 儲存對話名稱與內容，並製作成腳本化物件
    /// </summary>
    [CreateAssetMenu(menuName = "Misun/Dialogue Data", fileName = "New Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("對話者名稱")]
        public string dialogueName;
        [Header("對話者內容"), TextArea(2,10)]
        public string[] dialogueContents;
    
    
    
    }

}

