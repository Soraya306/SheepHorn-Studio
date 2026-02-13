using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float coins;
    public Text CoinsTXT;

    //Conectar con el inventario
   
    //Arrastrar tus ScriptableObjects (patata, fresa...)
    public ItemData[] itemsDisponibles;

    void Start()
    {
        CoinsTXT.text =  coins.ToString();

        //Productos
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Precio
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 20;
        shopItems[2, 4] = 30;

        //Cantidad
        shopItems[3, 1] = 10;
        shopItems[3, 2] = 10;
        shopItems[3, 3] = 10;
        shopItems[3, 4] = 10;
    }

    public void Buy()
    {
        GameObject ButtonRef = EventSystem.current.currentSelectedGameObject;
        int id = ButtonRef.GetComponent<ButtonInfo>().ItemID;

        //Comprueba si tienes monedas Y si queda stock
        if (coins >= shopItems[2, id] && shopItems[3, id] > 0)
        {
            coins -= shopItems[2, id];
            //Resta 1 al stock
            shopItems[3, id]--;

            //AÑADIR AL INVENTARIO
            if (InventoryManager.Instance != null && itemsDisponibles.Length >= id)
            {
                // Pasamos el ItemData de la lista directamente
                InventoryManager.Instance.add(itemsDisponibles[id - 1]);
            }

            CoinsTXT.text = coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().CantidadTxt.text = shopItems[3, id].ToString();
        }
    }
    /*
     * public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        int id = ButtonRef.GetComponent<ButtonInfo>().ItemID;

        if (coins >= shopItems[2, id])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            if (shopItems[3, id]>=1)
            {
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;


                CoinsTXT.text = "Coins:" + coins.ToString();
                ButtonRef.GetComponent<ButtonInfo>().CantidadTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

            }
        }
    }
    */
}
