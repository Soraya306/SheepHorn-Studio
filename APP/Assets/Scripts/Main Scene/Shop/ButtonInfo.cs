using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{

    public int ItemID;
    public Text CantidadTxt;
    public Text PriceTxt;
    public GameObject ShopManager;
    public int[,] shopItems = new int[10, 10];

    void Start()
    {
        ShopManager shop = ShopManager.GetComponent<ShopManager>();

        PriceTxt.text = ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        CantidadTxt.text = ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();
    }
    void Update()
    {
        if (ShopManager != null)
        {
            ShopManager shopScript = ShopManager.GetComponent<ShopManager>();
            int precio = shopScript.shopItems[2, ItemID];

            PriceTxt.text =   precio.ToString();
            CantidadTxt.text = shopScript.shopItems[3, ItemID].ToString();

            // Esto imprimirá en la consola el precio que el script está leyendo
            Debug.Log("Soy el botón " + ItemID + " y mi precio es: " + precio);
        }
        else
        {
            Debug.LogWarning("El objeto ShopManager no está asignado en el inspector.");
        }
    }
}
