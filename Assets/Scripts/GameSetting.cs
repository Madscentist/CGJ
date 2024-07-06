using System.Collections;
using System.Collections.Generic;
using Game.DialogBox;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "Config/GameSetting")]
    public class GameSetting : ScriptableObject
    {
        public static GameSetting _instance;
        public static GameSetting Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<GameSetting>("GameSetting");
                }
                return _instance;
            }
        }

        [SerializeField] private KeyCode _keyCode_NextDialog;
        public static KeyCode KeyCode_NextDialog
            => Instance == null ? default : Instance._keyCode_NextDialog;

        #region UI预制体
        [SerializeField] private UI_DialogBox _UI_DialogBox_Default;
        public static UI_DialogBox UI_DialogBox_Default
            => Instance?._UI_DialogBox_Default;
        #endregion
    }
}