using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    [Header("Scripts")]
    public Item Item;
    public RaycastSystem Ray;
    
    public InfoBetweenScenes Info;

    [Header("Bools")]
    public bool isPickup;
    public bool Pick=true;

    [Header("Units")]
    public int Patata_Unit;
    public int Fresa_Unit;
    public int Tomate_Unit;
    public int Sandia_Unit;

    private void Awake()
    {

       
        

    }
    private void Start()
    {
        Ray = GameObject.Find("Serpiente").gameObject.GetComponent<RaycastSystem>();
        Ray.Map.Player.Interactions.performed += Obtener_Objetos =>
        {
            
            if (Pick)
            {
               
               
                if (Ray.pickup)
                {
                    Pickup();
                    isPickup = false;
                }
                else if (isPickup)
                {
                    isPickup = false;
                }
                Pick = false;
            }


        };
    }
    private void Update()
    {
        if (Ray.Hit.collider!=null)
        {
            if (gameObject.name == Ray.Hit.collider.gameObject.name)
            {
                Pick = true;
            }
            
        }
        
    }

    public void Pickup()
    {
        if (Ray.Hit.collider!=null)
        {
            if (Ray.Hit.collider.tag!="puerta")
            {
               
                //Manager.Instance.add(Ray.Hit.collider.gameObject.GetComponent<ItemData>());
                if (Ray.siembra)
                {
                    if (Ray.Hit.collider.gameObject.GetComponent<ItemData>().Item.id == Ray.Fresas.GetComponent<ItemData>().Item.id)
                    {
                        Fresa_Unit = Random.Range(2, 4);
                        for (int i = 0; i < Fresa_Unit; i++)
                        {
                            InventoryManager.Instance.add(Ray.Hit.collider.gameObject.GetComponent<ItemData>());
                        }
                    }
                    if (Ray.Hit.collider.gameObject.GetComponent<ItemData>().Item.id == Ray.Patatas.GetComponent<ItemData>().Item.id)
                    {
                        Patata_Unit = Random.Range(2, 4);
                        for (int i = 0; i < Patata_Unit; i++)
                        {
                            InventoryManager.Instance.add(Ray.Hit.collider.gameObject.GetComponent<ItemData>());
                        }
                    }
                    if (Ray.Hit.collider.gameObject.GetComponent<ItemData>().Item.id == Ray.Tomates.GetComponent<ItemData>().Item.id)
                    {
                        Tomate_Unit = Random.Range(2, 4);
                        for (int i = 0; i < Tomate_Unit; i++)
                        {
                            InventoryManager.Instance.add(Ray.Hit.collider.gameObject.GetComponent<ItemData>());
                        }
                    }
                    if (Ray.Hit.collider.gameObject.GetComponent<ItemData>().Item.id == Ray.Sandias.GetComponent<ItemData>().Item.id)
                    {
                        Sandia_Unit = Random.Range(2, 4);
                        for (int i = 0; i < Sandia_Unit; i++)
                        {
                            InventoryManager.Instance.add(Ray.Hit.collider.gameObject.GetComponent<ItemData>());
                        }
                    }
                   

                    
                    //Ray.Hit.collider.gameObject.SetActive(false);
                   Destroy(Ray.Hit.collider.gameObject);
                    Ray.Tierra1.GetComponent<Collider>().enabled = true;
                    Ray.Tierra2.GetComponent<Collider>().enabled = true;
                    Ray.Tierra3.GetComponent<Collider>().enabled = true;
                    Ray.Tierra4.GetComponent<Collider>().enabled = true;
                    Ray.Tierra5.GetComponent<Collider>().enabled = true;
                    Ray.Tierra6.GetComponent<Collider>().enabled = true;
                    Ray.Tierra7.GetComponent<Collider>().enabled = true;
                    Ray.Tierra8.GetComponent<Collider>().enabled = true;
                    //Ray.Hit.collider.GetComponentInParent<Collider>().enabled = true;
                }
              
                Debug.Log(Ray.Hit.collider.gameObject);
            }
            
        }
       
       


    }
}
