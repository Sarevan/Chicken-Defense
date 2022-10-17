using UnityEngine;

namespace Utils
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get => instance;

            private set
            {
                if (instance != null && value != null)
                {
                    Debug.LogError($"There is another instance of {typeof(T)} object in the scene.");
                }

                instance = value;
            }
        }

        protected virtual void Awake() => Instance = (T)this;

        protected virtual void OnDestroy() => Instance = null;
    }
}