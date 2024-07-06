using System.Collections;
using System.Collections.Generic;
using Game;
using Game.DialogBox;
using UnityEngine;

public class Test_Mmang : MonoBehaviour
{

    [SerializeField] private List<uint> _testDialogIDs;
    private int _selectedIndex = 0;

    public DialogBox DialogBox { get; private set; }

    private void Start()
    {
        DialogBox = DialogUtil.CreateDialogBox();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            NextDialog();

        if (Input.GetKeyDown(KeyCode.Q))
            EffectManager.Instance.StartHurtEffect(0.5f);
    }

    private void NextDialog()
    {
        if (DialogBox.IsDialogging)
            return;
        DialogBox.StartDialog(_testDialogIDs[_selectedIndex]);

        _selectedIndex++;
        if (_selectedIndex >= _testDialogIDs.Count)
            _selectedIndex = 0;
    }

}