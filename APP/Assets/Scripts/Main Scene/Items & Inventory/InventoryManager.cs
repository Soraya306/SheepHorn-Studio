using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Scripts")]
    public static InventoryManager Instance;
    public RaycastSystem Ray;
    public InfoBetweenScenes Info;
    public Transform ItemContent;

    [Header("Lists")]
    public List<ItemData> Items=new List<ItemData>();
    public List<GameObject> Objects = new List<GameObject>();

    [Header("Other")]
    public GameObject InventoryItem;
    public bool set = true;

    private void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Info = GameObject.Find("GameManager").GetComponent<InfoBetweenScenes>();
        for (int i=1;i<=Info.ItemsInventario.Count;i++)
        {
            i--;
            Items.Add(Info.ItemsInventario[i].GetComponent<ItemData>());
            i++;
        }
    }

    public void add(ItemData item)
    {
        for (int i=0;i<Objects.Count;i++)
        {
            if (item.Item.id == Objects[i].GetComponent<ItemData>().Item.id)
            {
                Items.Add(Objects[i].GetComponent<ItemData>());
            }
        }
    }
    public void remove(ItemData item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject Obj = Instantiate(InventoryItem, ItemContent);
            TMP_Text texto=Obj.transform.GetChild(0).GetComponent<TMP_Text>();
            var ItemIcon = Obj.transform.Find("ItemIcon").GetComponent<Image>();
            texto.text=item.GetComponent<ItemData>().Item.itemName;
            ItemIcon.sprite=item.GetComponent<ItemData>().Item.icon;
        }

    }
}
