using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DialogBox
{

    public enum DialogActionType
    {
        ShowText,
        Wait,
        WaitButtonPressed
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

    [System.Serializable]
    public class DialogData
    {
        [SerializeField] private string _name = "Dialog";
        [SerializeField] private uint _id;
        [SerializeField] private List<DialogActionSetting> _actions;
        public string Name => _name;
        public uint ID => _id;
        public List<DialogActionSetting> ActionSettings => _actions;
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

        private void OnValidate() => CheckTypeChange();
        private void CheckTypeChange()
        {
            foreach (var data in Datas)
            {
                foreach (var setting in data.ActionSettings)
                {
                    if (setting.Action == null || DialogUtil.TypeDict[setting.Type] != setting.Action.GetType())
                    {
                        setting.Action = System.Activator.CreateInstance(DialogUtil.TypeDict[setting.Type]) as DialogAction;
                    }
                }
            }
        }

    }
}