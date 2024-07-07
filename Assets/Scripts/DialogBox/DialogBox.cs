using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DialogBox
{
    public class DialogBox
    {
        #region 
        public bool IsDialogging { get; private set; } = false;
        public DialogData CurDialogData { get; private set; }

        public UI_DialogBox UI { get; private set; }

        public bool SkipKeyPressed { get; private set; }
        #endregion

        private Coroutine _coroutine;

        public void Init(UI_DialogBox ui)
        {
            UI = ui;
        }

        public void Dispose()
        {
            GameObject.Destroy(UI);
        }

        public void Update(float dt)
        {
            SkipKeyPressed = Input.GetKeyDown(GameSetting.KeyCode_NextDialog);
            if (IsDialogging)
                DialogUpdate(dt);
        }

        private void DialogUpdate(float dt)
        {

        }

        private IEnumerator DialogCoroutine()
        {
            foreach (var setting in CurDialogData.ActionSettings)
            {
                if (setting.Action == null)
                    continue;
                yield return setting.Action.DoAction(this);
            }
            yield return null;
            _coroutine = null;
            StopDialog();
        }

        #region
        public void StartDialog(DialogData data)
        {
            if (data == null)
                return;

            if (IsDialogging)
                StopDialog();

            UI.SetBG(0);
            UI.gameObject.SetActive(true);
            UI.ClearText();
            CurDialogData = data;
            IsDialogging = true;
            _coroutine = DialogBoxManager.Instance.StartCoroutine(DialogCoroutine());
        }

        public void StopDialog()
        {
            UI.gameObject.SetActive(false);
            CurDialogData = null;
            IsDialogging = false;
            if (_coroutine != null)
            {
                DialogBoxManager.Instance.StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
        #endregion        
    }

}