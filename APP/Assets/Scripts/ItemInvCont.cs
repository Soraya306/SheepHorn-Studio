using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInvCont : MonoBehaviour
{
   ItemData item;
    public InventoryManager inventoryManager;
    public raycastpr r;
    public void RemoveItem()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        r = obj.GetComponent<raycastpr>();
        
        GameObject man = GameObject.FindGameObjectWithTag("Respawn");
        inventoryManager =man.GetComponent<InventoryManager>();
        inventoryManager.Instance.remove(item);
        gameObject.SetActive(false);    

    }

    public void additem(ItemData newdata)
    {
        item = newdata;
    }
}
