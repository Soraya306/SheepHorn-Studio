using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Info info;
    public Item Item;

    private void Awake()
    {
        info= GameObject.FindGameObjectWithTag("Finish").GetComponent<Info>();
        foreach (int a in info.ids)
        {
            if (a == gameObject.GetComponent<ItemData>().Item.id)
            {
               // gameObject.SetActive(false);
            }

        }
    }
    
}
