using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public InventoryManager Instance; //NO TOCAR
    public List<ItemData> Items=new List<ItemData>(); //LISTA DE OBJETOS QUE SE TIENEN ACTUALMENTE
    public List<GameObject> GG=new List<GameObject>(); //LISTA DE OBJETOS DISPONIBLES
    public raycastpr ra;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public bool set=true;
    
    public Info inff;

    private void Awake()
    {
        Instance = this;
        
    }

    //AÑADE OBJETOS A LA LISTA
    public void add(ItemData item)
    {
        //RECORRE LA LISTA DE OBJETOS DISPONIBLES
        for (int i=0;i<GG.Count; i++)
        {
            //COMPRUEBA SI SE TIENE EL OBJETO ACTUALMENTE
            if (item.Item.id == GG[i].GetComponent<ItemData>().Item.id)
            {
                Items.Add(GG[i].GetComponent<ItemData>()); //AÑADE EL OBJETO A LA LISTA
            }
        }
        
    }
    //QUITA OBJETOS
    public void remove (ItemData item)
    {
        Items.Remove(item);
    }

    //GENERAR EL INVENTARIO VISIBLE
    public void ListItems()
    {
        //NO TOCAR
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            //BUSCA EL OBJETO
            TMP_Text texto = obj.transform.GetChild(0).GetComponent<TMP_Text>();
            var itemIcon=obj.transform.Find("ItemIcon").GetComponent<Image>();
            //PONE IMAGEN Y NOMBRE
            texto.text = item.GetComponent<ItemData>().Item.itemName;
            itemIcon.sprite = item.GetComponent<ItemData>().Item.icon;

        }
       
    }

   

}
