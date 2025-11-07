using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public raycastpr ray;
    public DataSaver saveSystem;
    public Info inn;

    private void Update()
    {
        if (ray.bat)
        {
            //saveSystem.Save();
            inn.cambio = true;
            inn.posit();
            SceneManager.LoadScene(1);
            ray.bat = false;
        }
    }


}
