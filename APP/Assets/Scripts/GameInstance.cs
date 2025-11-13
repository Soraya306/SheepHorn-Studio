using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class GameInstance : MonoBehaviour
{
    //SINGLETON
    //HACE QUE NO SE ELIMINE EL OBJETO ENTRE ESCENAS

    public static GameInstance instance = null;

    private void Awake()
    {
        if (instance==null)
        {
            instance=this;
        }else if (instance!=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad  (gameObject);
    }

}