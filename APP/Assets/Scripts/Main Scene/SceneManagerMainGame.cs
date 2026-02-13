using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMainGame : MonoBehaviour
{
    [Header("Menus")]
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    [Header("Scripts")]
    public RaycastSystem RaycastSystem;
    public InfoBetweenScenes Info;

    private void Awake()
    {
        Info = GameObject.Find("GameManager").gameObject.GetComponent<InfoBetweenScenes>();
    }
    public void OptionsMenuMainGame()
    {
        if (!OptionsMenu.activeInHierarchy)
        {
            OptionsMenu.SetActive(true);
        }
    }
    public void ContiuneButton()
    {
       
        if (PauseMenu.activeInHierarchy)
        {
            
            PauseMenu.SetActive(false);
            RaycastSystem.MenuDesact = false;
            Info.pause = false;
        }
    }
    public void ExitOptions() 
    {
        if (OptionsMenu.activeInHierarchy)
        {
            OptionsMenu.SetActive(false);
        }
            
    }
    public void ExittoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void InteriorSerpiente()
    {
        SceneManager.LoadScene(2);
    }

    public void InteriorGallina()
    {
        SceneManager.LoadScene(3);
    }
    public void InteriorVaca()
    {
        SceneManager.LoadScene(4);
    }
    public void InteriorCerdo()
    {
        SceneManager.LoadScene(5);
    }
    public void CarneroBattle()
    {
        if (Info.carnero)
        {
            SceneManager.LoadScene(6);
        }
        
    }
   
}
