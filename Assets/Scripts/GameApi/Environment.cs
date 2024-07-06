using System;
using UnityEngine;

namespace GameApi
{
    public class Environment<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get => _instance
            ;
            private set => _instance = value;
        }

        private void Awake()
        {
            _instance = this as T;
        }
    }
}