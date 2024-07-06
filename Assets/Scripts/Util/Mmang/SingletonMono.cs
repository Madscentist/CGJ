using UnityEngine;

namespace Mmang
{
    public abstract class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        public static T Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                }

                return _instance;
            }
        }

        private static T _instance;
        protected virtual void Awake()
        {
            _instance = (T)this;
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }
    }
}

