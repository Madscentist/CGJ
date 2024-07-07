using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DialogBox
{

    [CreateAssetMenu(fileName = "DialogData", menuName = "Config/DialogData")]
    public class DialogData : ScriptableObject
    {
        [SerializeField] private string _name = "Dialog";
        [SerializeField] private uint _id;
        [SerializeField] private List<DialogActionSetting> _actions;
        public string Name => _name;
        public uint ID => _id;
        public List<DialogActionSetting> ActionSettings => _actions;

        private void OnValidate() => CheckTypeChange();
        private void CheckTypeChange()
        {

            foreach (var setting in ActionSettings)
            {
                if (setting.Action == null || DialogUtil.TypeDict[setting.Type] != setting.Action.GetType())
                {
                    setting.Action = System.Activator.CreateInstance(DialogUtil.TypeDict[setting.Type]) as DialogAction;
                }
            }

        }
    }
}