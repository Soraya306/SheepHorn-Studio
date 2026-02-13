using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMainMenu : MonoBehaviour
{

    [Header("Menus")]
    public GameObject OptionsMenu;
   
   public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitOptionsMenu()
    {
        if (OptionsMenu.activeInHierarchy)
        {
            OptionsMenu.SetActive(false);
        }
    }
    public void OptionsButton()
    {
        if (!OptionsMenu.activeInHierarchy)
        {
            OptionsMenu.SetActive(true);
        }
    }

    public void ExitButton()
    {
        //EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
