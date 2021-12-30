using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager<T> : MonoBehaviour where T : BaseManager<T>
{
    public static T instance;
    // Start is called before the first frame update
    protected void Awake()
    {
        if (instance == null)
        { 
            instance = (T)this;
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
