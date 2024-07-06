using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace GameApi
{
    public class GameManager : MonoBehaviour
    {
        public string sceneName;

        public int health;
        public double keys;

        public TMP_Text text;

        public int tool1Count;
        public int tool2Count;
        public int tool3Count;
        public int tool4Count;
        
        private float _recentRate = 10;
        private void Start()
        {
            health = 3;
        }

        private void Update()
        {
            // if (Input.GetKeyDown(KeyCode.Mouse0))
            // {
            //     GotKey();
            // }

            text.text = Math.Truncate(keys * 100) / 100 + "%";
            
            if (health == 0)
            {
                //TODO restart this Scene
            }
        }
        
        public void GotKey()
        {
            keys += Random.Range(_recentRate * 0.7f, _recentRate);

            if (100 - keys < _recentRate)
            {
                _recentRate /= 10;
            }


        }
        
    }
}