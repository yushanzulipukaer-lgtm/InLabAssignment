using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
        where T : MonoBehaviour
{
    public static T Instance {get; private set;}
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this as T;
    }

}
