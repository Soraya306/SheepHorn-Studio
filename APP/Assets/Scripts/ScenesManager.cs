using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public raycastpr ray;
    public DataSaver saveSystem;
    public Info inn;
    public InventoryManager set;

    private void Update()
    {
        if (ray.bat)
        {
            //saveSystem.Save();
            inn.cambio = true;
            inn.posit();
            set.set = false;
            SceneManager.LoadScene(1);
            ray.bat = false;
        }
    }


}
