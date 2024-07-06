using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DialogBox
{
    public static class DialogUtil
    {
        public static Dictionary<DialogActionType, System.Type> TypeDict = new()
        {
            [DialogActionType.ShowText] = typeof(DA_ShowText),
            [DialogActionType.Wait] = typeof(DA_Wait),
            [DialogActionType.WaitButtonPressed] = typeof(DA_WaitButtonPressed),
        };

        public static DialogBox CreateDialogBox(UI_DialogBox prefab = null)
        {
            if (prefab == null)
                prefab = GameSetting.UI_DialogBox_Default;
            DialogBox box = new();
            var uiInstance = CreateUI_DialogBox(prefab);
            box.Init(uiInstance);
            DialogBoxManager.AddBox(box);
            return box;
        }

        public static UI_DialogBox CreateUI_DialogBox(UI_DialogBox prefab)
        {
            if (prefab == null)
                return null;
            return GameObject.Instantiate(prefab, UIManager.Canvas.transform);
        }

        public static void StartDialog(this DialogBox dialogBox, uint id)
        {
            var data = DialogConfig.Instance.GetData(id);
            if (data == null)
                return;
            dialogBox.StartDialog(data);
        }

    }
}