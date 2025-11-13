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
    public Info inf;
    public bool C=false;

    //MAPA ACCIONES
    private void Awake()
    {
        inf= GameObject.FindGameObjectWithTag("Finish").GetComponent<Info>();
        EnergyHud.HUDSetup(player);
        player.Energy=player.MaxEnergy;
        ray = GameObject.FindGameObjectWithTag("Player").GetComponent<raycastpr>();
        ray.mapa.Player.pickup.performed += hola =>
        {
            EnergyHud.HUDSetup(player);
            if (ray.pick)
            {
                Pickup();
                inf.ids.Add(ray.hit.collider.gameObject.GetComponent<ItemData>().Item.id);
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
           
            ray.hit.collider.gameObject.SetActive(false);
            GameObject.Find("Suelo").GetComponent<Collider>().enabled = true;
        }
        else
        {
            GameObject.Find("Suelo").GetComponent<Collider>().enabled = true;
            //ray.o.enabled = true;
            Destroy(ray.hit.collider.gameObject);
            
        }


        
 



        GameObject.Find("Suelo").GetComponent<Collider>().enabled = true;


        player.Energy = player.Energy - Item.value;
        Debug.Log("el item es"+ray.hit.collider.gameObject);

    }

  

    


}
