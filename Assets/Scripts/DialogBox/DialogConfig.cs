using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DialogBox
{

    public enum DialogActionType
    {
        ShowText,
        Wait,
        WaitButtonPressed,
        ClearText,
        NewLine,
        SetBG
    }

    [System.Serializable]
    public abstract class DialogAction
    {
        public abstract IEnumerator DoAction(DialogBox dialogBox);
    }

    [System.Serializable]
    public class DialogActionSetting
    {
        public DialogActionType Type;
        [SerializeReference]
        private DialogAction _action;
        public DialogAction Action
        {
            get => _action;
            set => _action = value;
        }
    }

    [CreateAssetMenu(fileName = "DialogConfig", menuName = "Config/DialogConfig")]
    public class DialogConfig : ScriptableObject
    {
        public static DialogConfig _instance;
        public static DialogConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<DialogConfig>("Config/DialogConfig");
                }
                return _instance;
            }
        }

        [SerializeField] private List<DialogData> _datas;
        public List<DialogData> Datas => _datas;

        public DialogData GetData(uint id)
        {
            foreach (var data in Datas)
            {
                if (data.ID == id)
                    return data;
            }
            return null;
        }

    }
}