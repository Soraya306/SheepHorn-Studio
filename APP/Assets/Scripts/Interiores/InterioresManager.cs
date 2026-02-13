using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterioresManager : MonoBehaviour
{
    [Header("Scripts")]
    public RaycastSystem Ray;
    public InfoBetweenScenes Info;


    private void Awake()
    {
        Info = GameObject.Find("GameManager").GetComponent<InfoBetweenScenes>();
    }
    public void ReturnMainScene()
    {
        Info.change = false;
        if (Info.returning)
        {
            Info.posicioncerdo = false;
            Info.posiciongallina = false;
            Info.posicionvaca=false;
            SceneManager.LoadScene(1);
        }
    }
    public void GallinaBattle()
    {
        if (Info.gallinabatallaactiva)
        {
            SceneManager.LoadScene(7);
        }
        
    }
    public void CerdoBattle()
    {
        if (Info.cerdobatallaactiva)
        {
            SceneManager.LoadScene(8);
        }
        
    }
    public void VacaBattle()
    {
        if (Info.vacabatallaactiva)
        {
            SceneManager.LoadScene(9);
        }
        
    }
}
