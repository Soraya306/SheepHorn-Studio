using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public   InventoryManager Instance;
    public List<ItemData> Items=new List<ItemData>();
    public List<GameObject> GG=new List<GameObject>();
    public raycastpr ra;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public bool set=true;
    public ItemInvCont[] InventoruItems;
    public Info inff;

    private void Awake()
    {
        Instance = this;
        
    }

    public void add(ItemData item)
    {
        for (int i=0;i<GG.Count; i++)
        {
            if (item.Item.id == GG[i].GetComponent<ItemData>().Item.id)
            {
                Items.Add(GG[i].GetComponent<ItemData>());
            }
        }
        
    }
    public void remove (ItemData item)
    {
        Items.Remove(item);
    }

    //ANADE COSAS A LA LISTA DE ITEMS
    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            TMP_Text texto = obj.transform.GetChild(0).GetComponent<TMP_Text>();
         
           var itemIcon=obj.transform.Find("ItemIcon").GetComponent<Image>();

            texto.text = item.GetComponent<ItemData>().Item.itemName;
            itemIcon.sprite = item.GetComponent<ItemData>().Item.icon;

        }
       
    }

   /* public void SetInventoryItems()
    {
        InventoruItems = ItemContent.GetComponentsInChildren<ItemInvCont>();

        for (int i=0;i<Items.Count;i++)
        {
            InventoruItems[i].additem(Items[i]);
        }

    }*/

}
