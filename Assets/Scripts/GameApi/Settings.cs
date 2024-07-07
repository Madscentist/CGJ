using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameApi
{
    [CreateAssetMenu(menuName = "GameSetting")]
    public class Settings : ScriptableObject
    {
        public string level1;
        public bool level1Finished;
        public string level2;
        public bool level2Finished;

        public string level3;

    }
}