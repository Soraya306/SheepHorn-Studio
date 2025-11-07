using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform play;
    public int sped;
    public Vector3 off;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = play.transform.position + off;
    }
}
