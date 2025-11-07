using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class raycastpr : MonoBehaviour
{

    float maxdist;
    public bool tocar;
    public Inputmaptest mapa;
    public bool tap=true;
    public bool dormir = false;
    public bool act=false;
    public bool ishitting = false;
    public bool pick=false;
    public bool picking = false;
    public RaycastHit hit;
    public InventoryManager Man;
    public GameObject image;
    public GameObject menu;
    public GameObject Char1;
    public GameObject Char2;
    public GameObject TextBox;
    public GameObject Battle;
    public bool menuactivo=true;
    public bool menudes=false;
    public bool bat=false;
    public TextManager texto;
    public GameObject Pat;
    public GameObject Fres;
    public ItemData dat;
    int a=0;
    public GameObject but1;
    public GameObject but2;
    public ItemPickup picka;
    public GameObject obj;
    //public Collider o;
    public bool siemb=false;
    public bool c1 = false;
    public bool c2 = false;
    public Info info;
    public GameObject Suel1;
    public GameObject Suel2;
    public GameObject Suel3;


    private void Awake()
    {
        info=GameObject.FindGameObjectWithTag("Finish").GetComponent<Info>();
        mapa = new Inputmaptest();
        if (info.pat1)
        {
            obj = Instantiate(Pat);
            obj.transform.position = new Vector3(GameObject.Find("Suelo").GetComponent<Transform>().position.x, GameObject.Find("Suelo").GetComponent<Transform>().position.y, GameObject.Find("Suelo").GetComponent<Transform>().position.z);
            GameObject.Find("Suelo").GetComponent<Collider>().enabled = false;
            obj.transform.SetParent(GameObject.Find("Suelo").GetComponent<Transform>().transform);
        }
        
        mapa.Player.Menu.performed += hola =>
        {
            if (!menudes)
            {
                menudes = true;
                menuactivo = false;
                if (!menu.activeInHierarchy)
                {
                    menu.SetActive(true);
                }
            }else if (!menuactivo)
            {
                menudes = false;
                menuactivo = true;
                if (menu.activeInHierarchy)
                {
                    menu.SetActive(false);
                }
            }

            
        };
        
        mapa.Player.interact.performed += hola =>
        {
            if (ishitting)
            {
                if (!act)
                {
                    tocar = true;
                    act = true;
                    tap = false;
                    Debug.Log("tap");
                }
                else if (!tap)
                {
                    tocar = false;
                    act = false;
                    tap = true;
                    Debug.Log("O");
                }
                
                
                

            }
            


        };
        mapa.Player.pickup.performed += hola => 
        {
            if (c1)
            {
                text1();
            }
            if (c2)
            {
                text2();
            }
            c1=false;
            c2=false;
        
        };
       
        


        
    }


    
    void Start()
    {
       

       
    }

    private void OnEnable()
    {
        mapa.Enable();
    }

    private void OnDisable()
    {
        mapa.Disable(); 
    }

    
    void Update()
    {
        //SISTEMA DE RAYCAST
        maxdist = 2f;
        
        Ray ray=new Ray(transform.position,transform.forward);
        
        Debug.DrawRay(ray.origin, ray.direction * maxdist, Color.green);

        for (int i = 0; i < Man.Items.Count; i++)
        {
            a = Man.Items[i].Item.id;
            Debug.Log(a);

            if (a == 1)
            {
                but1.SetActive(true);
            }
            else if (a == 2)
            {
                but2.SetActive(true);
            }
        }

        if (Physics.Raycast(ray, out hit,maxdist))
        {
            //COLISIONA CON DIFERENTES OBJETOS
            if (hit.collider.gameObject.tag=="noobcet")
            {
                ishitting = true;
            }
            if (hit.collider.gameObject.tag == "object")
            
            {
                pick = true;
                picka = hit.collider.gameObject.GetComponent<ItemPickup>();
                obj = hit.collider.gameObject.GetComponent<GameObject>();
                //o = hit.collider.gameObject.GetComponent<Collider>();
                

               
                
                

            }
            else
            {
                pick = false;
            }
            if (hit.collider.gameObject.tag=="CAMA")
            {
                dormir = true;
            }
            if (hit.collider.gameObject.tag=="Charac1")
            {
                c1=true;
               
               // texto.index = 0;
            }
            
            else if (hit.collider.gameObject.tag == "Charac2")
            {
               
               c2 = true;
                //texto.index = 0;
            }

            if (hit.collider.gameObject==Battle)
            {
                bat=true;
                
            }

           


        }
        else
        {
            ishitting = false;
            pick = false;
            dormir = false;
        }
        //INVENTARIO
        if (tocar)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            
            if (!image.activeInHierarchy)
            {
                image.SetActive(true);
            }
            Man.Instance.ListItems();

        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            if (image.activeInHierarchy)
            {
                image.SetActive(false);
            }
        }



    }
   public void text1()
    {
        Char2.SetActive(false);
        if (!TextBox.activeInHierarchy)
        {
            TextBox.SetActive(true);
            if (!Char1.activeInHierarchy)
            {
                Char1.SetActive(true);
            }
        }
        else
        {
            if (!Char1.activeInHierarchy)
            {
                Char1.SetActive(true);
            }
        }
        texto = hit.collider.gameObject.GetComponentInChildren<TextManager>();
    }
    public void text2()
    {
        Char1.SetActive(false);
        if (!TextBox.activeInHierarchy)
        {
            TextBox.SetActive(true);
            if (!Char2.activeInHierarchy)
            {
                Char2.SetActive(true);
            }
        }
        else
        {
            if (!Char2.activeInHierarchy)
            {
                Char2.SetActive(true);
            }
        }
        texto = hit.collider.gameObject.GetComponentInChildren<TextManager>();
    }

    public void siembraP()
    {
        if (hit.collider.gameObject.tag == "Sembrable")
        {
            
            Debug.Log("Golpea");
            if (hit.collider.gameObject.transform.childCount == 0)

            {
                if (hit.collider.gameObject.name == Suel1.name)
                {
                    obj = Instantiate(Pat);
                    obj.transform.position= Suel1.transform.position;
                    Suel1.GetComponent<Collider>().enabled = false;
                    obj.transform.SetParent(Suel1.GetComponent<Transform>().transform);
                    siemb = true;
                    info.pat1 = true;
                }

                if (hit.collider.gameObject.name == Suel2.name)
                {
                    obj = Instantiate(Pat);
                    obj.transform.position = Suel2.transform.position;
                    Suel2.GetComponent<Collider>().enabled = false;
                    obj.transform.SetParent(Suel2.GetComponent<Transform>().transform);
                    siemb = true;
                    info.pat1 = true;
                }
                
                 
               
                
                
               






            }
            else
            {
                if (picka)
                {
                    Suel1.GetComponent<Collider>().enabled = true;

                    obj.transform.SetParent(null);
                }
            }
        }
    }

    public void siembraF()
    {
        if (hit.collider.gameObject.tag == "Sembrable")
        {
            Debug.Log("Golpea");
            if (hit.collider.gameObject.transform.childCount == 0)

            {
                
                obj = Instantiate(Fres);
                obj.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y, hit.collider.gameObject.transform.position.z);
                //o = hit.collider.gameObject.GetComponent<Collider>();
                //o.enabled = false;
                obj.transform.SetParent(hit.collider.gameObject.transform);
                //o = hit.collider.gameObject.GetComponentInParent<Collider>();
                siemb = true;






            }
            else
            {
                if (picka)
                {
                   //o.enabled = true;

                    obj.transform.SetParent(null);
                }
            }
        }
    }
}
