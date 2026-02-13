using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesBehaviour : MonoBehaviour
{
    public GameObject Sol;
    public GameObject Farolas;
    public InfoBetweenScenes Info;
    public int Contador;
    public float Girox;
    public int RotationNum;


    private void Awake()
    {
        Info = GameObject.Find("GameManager").GetComponent<InfoBetweenScenes>();
        Contador = RotationNum;
        Sol.transform.rotation = Quaternion.Euler(Info.Rotation, -90, 0);
    }
    void Start()
    {
       
    }

    
    void Update()
    {
        if (!Info.pause)
        {
            if (Contador != 9280)
            {

                Tiempo();

                if (Contador == 9200)
                {
                    Farolas.SetActive(true);

                    Girox = 1;

                }
            }
        }
       
        RotationNum = Contador;
        Info.Rotation = Sol.transform.rotation.eulerAngles.x;
        
        
    }

    public void Tiempo()
    {
        Sol.gameObject.transform.Rotate(Girox, 0, 0);
        
        Contador++;
    }

    
}
