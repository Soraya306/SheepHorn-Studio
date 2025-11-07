using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public float posx;
    public float posy;
    public float posz;
    public GameObject Jug;
    public bool cambio=false;
    public bool son1=false;
    public bool pat1 = false;
    private void Update()
    {
        Jug = GameObject.FindGameObjectWithTag("Player");
        
    }
    public void posit()
    {
        posx = Jug.transform.position.x;
        posy = Jug.transform.position.y;
        posz = Jug.transform.position.z;
    }
}
