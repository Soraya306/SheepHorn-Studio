using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Info : MonoBehaviour
{

    //DATOS QUE SE GUARDAN ENTRE ESCENAS

    public float posx;
    public float posy;
    public float posz;
    public GameObject Jug; //JUGADOR
    public bool cambio=false;
    public bool son1=false; //PARA SONIC
    public bool pat1 = false; //PARA PATATA
    public InventoryManager List;
    public List<ItemData> IT=new List<ItemData>();
    public bool a=false;
    public Item it;
    public int num1;
    public List<int> ids=new List<int>();
    private void Awake()
    {
        
    }
    private void Update()
    {
        Jug = GameObject.FindGameObjectWithTag("Player");

      

    }
    
    //GUARDA LA POSICION DEL OBJETO ANTES DE CAMBIAR DE ESCENA
    public void posit()
    {
        posx = Jug.transform.position.x;
        posy = Jug.transform.position.y;
        posz = Jug.transform.position.z;
       
        



    }
}
