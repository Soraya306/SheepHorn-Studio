using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    public raycastpr ray;
    public bool isPickup=true;
    public InventoryManager Man;
    public HUD EnergyHud;
    public PlayerStats player;
    public bool yes=false;
    
    public bool C=false;

    //MAPA ACCIONES
    private void Awake()
    {
        EnergyHud.HUDSetup(player);
        player.Energy=player.MaxEnergy;
        ray = GameObject.FindGameObjectWithTag("Player").GetComponent<raycastpr>();
        ray.mapa.Player.pickup.performed += hola =>
        {
            EnergyHud.HUDSetup(player);
            if (ray.pick)
            {
                Pickup();
                yes = true;
                isPickup =false;
                ray.pick = false;
               
            }
            else if(!isPickup)
            {
                
                isPickup = true;
            }
            if (ray.dormir)
            {
                player.Energy = player.MaxEnergy;
            }

        };
        

    }
  
    //PILLA EL OBJETO
    public void Pickup()
    {
        
        Man.Instance.add(ray.hit.collider.gameObject.GetComponent<ItemData>());
        if (!ray.siemb)
        {
            Destroy(ray.hit.collider.gameObject);
            //ray.hit.collider.gameObject.SetActive(false);
            GameObject.Find("Suelo").GetComponent<Collider>().enabled = true;
        }
        else
        {
            GameObject.Find("Suelo").GetComponent<Collider>().enabled = true;
            //ray.o.enabled = true;
            Destroy(ray.hit.collider.gameObject);
            
        }


        /* if (ray.o.transform.childCount != 0)
         {


         }
         else
         {

         }
 */



        GameObject.Find("Suelo").GetComponent<Collider>().enabled = true;


        player.Energy = player.Energy - Item.value;
        Debug.Log("el item es"+ray.hit.collider.gameObject);

    }

  

    private void Update()
    {
       
    }


}
