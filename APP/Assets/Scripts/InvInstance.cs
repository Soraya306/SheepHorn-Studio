using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvInstance : MonoBehaviour
{
    //NO

    public static InvInstance instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
