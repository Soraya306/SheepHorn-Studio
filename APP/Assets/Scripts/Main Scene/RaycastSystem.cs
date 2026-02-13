using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastSystem : MonoBehaviour
{
    [Header("Scripts")]
    public InputMap Map;
    public InfoBetweenScenes Info;
    public SceneManagerMainGame Manager;
    public InterioresManager IntManager;
   
    public ShopManager ShopMan;

    [Header ("Data")]
    public float MaxDist;
    public int ID;
    public int id1;
    public int id2;
    public int id3;
    public int id4;
    

    [Header("Bools")]
    public bool MenuAct;
    public bool MenuDesact;
    public bool InvAct;
    public bool InvDesact;
    public bool Serp;
    public bool gall;
    public bool vac;
    public bool cer;
    public bool siembra;
    public bool pickup;
    public bool carnbat;
    public bool cerdbat;
    public bool vacbat;
    public bool gallbat;
    public bool shop = false;

    [Header("Personajes")]
    public GameObject Carnero;
    public GameObject Vaca;
    public GameObject Cerdo;
    public GameObject Gallina;
    public GameObject Lagartija;

    public RaycastHit Hit;


    [Header("Objects")]
    public GameObject PauseMenu;
    public GameObject Inventory;
    public GameObject CasaSerpiente;
    public GameObject CasaGallina;
    public GameObject CasaVaca;
    public GameObject CasaCerdo;
    public GameObject Shop;
    public GameObject OBJ;
    public GameObject intcerdo;
    public GameObject intvaca;
    public GameObject intgall;
    public GameObject carni;

    [Header("Tierras")]
    public GameObject Tierra1;
    public GameObject Tierra2;
    public GameObject Tierra3;
    public GameObject Tierra4;
    public GameObject Tierra5;
    public GameObject Tierra6;
    public GameObject Tierra7;
    public GameObject Tierra8;

    [Header("Plantas")]
    public GameObject Fresas;
    public GameObject Patatas;
    public GameObject Sandias;
    public GameObject Tomates;
    public GameObject Fresas_button;
    public GameObject Tomates_button;
    public GameObject Patatas_button;
    public GameObject Sandias_button;

    [Header("Interiores")]
    public GameObject Return;
   

    

    private void Awake()
    {
        Map=new InputMap();
        Info = GameObject.FindGameObjectWithTag("InfoSaved").GetComponent<InfoBetweenScenes>();
        
       
        Map.Player.OpenMenu.performed += Open_Menu =>
        {
            if (!MenuDesact)
            {
                MenuDesact = true;
                MenuAct = false;
                if (!PauseMenu.activeInHierarchy)
                {
                    PauseMenu.SetActive(true);
                    Info.pause = true;

                }
            }else if (!MenuAct)
            {
                MenuDesact=false;
                MenuAct=true;
                if (PauseMenu.activeInHierarchy)
                {
                    PauseMenu.SetActive(false);
                    Info.pause = false;
                }
            }
        };
        Map.Player.Interactions.performed += Interact => 
        {
            if (Serp)
            {
                for (int i=1;i<=InventoryManager.Instance.Items.Count;i++)
                {
                    i--;
                    Info.ItemsInventario.Add(InventoryManager.Instance.Items[i].GetComponent<ItemData>());
                    i++;
                }
                Manager.InteriorSerpiente();
                
                
            }
            if (gall)
            {
                Manager.InteriorGallina();
            }
            if (vac)
            {
                Manager.InteriorVaca();
            }
            if (cer)
            {
                Manager.InteriorCerdo();    
            }
            
            if (Info.returning)
            {
                IntManager.ReturnMainScene();
            }
            if (carnbat)
            {
                Manager.CarneroBattle();
            }
            if (gallbat)
            {
                Info.dificultad_gallina = true;
                IntManager.GallinaBattle();
            }
            if (cerdbat)
            {
                Info.dificultad_cerdo = true;
                IntManager.CerdoBattle();
            }
            if (vacbat)
            {
                Info.dificultad_vaca = true;
                IntManager.VacaBattle();
            }
            if (shop)
            {
                if (!Shop.activeInHierarchy)
                {
                    Shop.SetActive(true);
                }
                else
                {
                    Shop.SetActive(false);
                }
            }


        };
        Map.Player.OpenInventory.performed += Open_inv =>
        {
            if (!InvDesact)
            {
                InvDesact = true;
                InvAct = false;
                if (!Inventory.activeInHierarchy)
                {
                    Inventory.SetActive(true);
                    InventoryManager.Instance.ListItems();
                }
            }else if (!InvAct)
            {
                InvDesact = false;
                InvAct = true;
                if (Inventory.activeInHierarchy)
                {
                    Inventory.SetActive(false);
                }
            }
        };
        

    }

    private void OnEnable()
    {
        Map.Enable();
    }
    private void OnDisable()
    {
        Map.Disable();
    }
    private void Update()
    {
       
        MaxDist = 3f;
       
        Ray Ray = new Ray(GameObject.Find("Pivote").GetComponent<Transform>().transform.position, transform.forward);
        Debug.DrawRay(Ray.origin, Ray.direction*MaxDist, Color.green);
        if (InventoryManager.Instance != null)
        {
            if (InventoryManager.Instance.Items.Count > 0)
            {
                for (int i = 0; i < InventoryManager.Instance.Items.Count; i++)
                {
                    ID = InventoryManager.Instance.Items[i].Item.id;
                   

                    if (ID == 1)
                    {
                        Fresas_button.SetActive(true);
                        id1++;
                    }
                    if (ID == 2)
                    {
                        Patatas_button.SetActive(true);
                        id2++;
                    }
                    if (ID == 3)
                    {
                        Tomates_button.SetActive(true);
                        id3++;
                    }
                    if (ID == 4)
                    {
                        Sandias_button.SetActive(true);
                        id4++;
                    }
                }
                
            }
           
            

        }

        if (Physics.Raycast(Ray, out Hit, MaxDist))
        {
            if (Hit.collider.gameObject==CasaSerpiente)
            {
                Serp = true;
                Info.casserp = true;
            }
            
            if (Hit.collider.gameObject == CasaGallina)
            {
                gall = true;
                Info.casgall=true;

            }
            if (Hit.collider.gameObject == CasaVaca)
            {
                vac = true;
                Info.casvaca = true;
            }
            if (Hit.collider.gameObject == CasaCerdo)
            {
                cer = true;
                Info.cascerd = true;
            }
            if (Hit.collider.tag == "planta")
            {
                pickup = true;
                Serp = false;
                Info.casserp = false;
            }
            if (Hit.collider.tag=="Tierras")
            {
                siembra = true;
                Serp = false;
                Info.casserp = false;
            }
            if (Hit.collider.gameObject==Return)
            {
                Info.returning = true;
            }else if (Hit.collider.gameObject != Return)
            {
                Info.returning = false;
            }
            if (Hit.collider.gameObject == Carnero)
            {

                Info.carnero = true;
                carnbat = true;
            }
            if (Hit.collider.gameObject == Gallina)
            {
                
                if (!Info.posiciongallina)
                {
                    gallbat = true;
                    Info.gallinabatallaactiva = true;
                }
            }
            if (Hit.collider.gameObject == Cerdo)
            {
                
                if (!Info.posicioncerdo)
                {
                    cerdbat = true;
                    Info.cerdobatallaactiva = true;
                }
                
            }
            if (Hit.collider.gameObject == Vaca)
            {
                if (!Info.posicionvaca)
                {
                    vacbat = true;
                    Info.vacabatallaactiva = true;
                }
                
            }
            if (Hit.collider.gameObject.tag=="tienda")
            {
                shop = true;
            }else if (Hit.collider.gameObject.tag != "tienda")
            {
                shop = false;
            }
                Debug.Log(Hit.collider.gameObject.tag);
        }
    }
}
