using Unity.VisualScripting;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
