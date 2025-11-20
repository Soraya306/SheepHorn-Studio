using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class raycastpr : MonoBehaviour
{

    float maxdist; //DISTANCIA MAX DEL RAYO
    public bool tocar;
    public Inputmaptest mapa; //INTERACTUAR
    public bool tap=true; //COMPROBANTE EN CONSOLA
    public bool dormir = false;
    public bool act=false; //COMPROBANTE EN CONSOLA
    public bool ishitting = false;
    public bool pick=false; //COMPROBANTE EN CONSOLA
    public bool picking = false;
    public RaycastHit hit; //CUANDO EL RAYO GOLPEA ALGO Y OBTIENE INFORMACION
    public InventoryManager Man; //ACCEDER A OTRO SCRIPT
    public GameObject image;
    public GameObject menu;
    public GameObject Char1;
    public GameObject Char2;
    public GameObject TextBox;
    public GameObject Battle;
    public bool menuactivo=true;
    public bool menudes=false;
    public bool bat=false; //BATALLA
    public TextManager texto;
    public GameObject Pat;
    public GameObject Fres;
    public ItemData dat; //ACCEDER A OTRO SCRIPT
    int a=0;
    public GameObject but1; //BOTONES PARA CULTIVAR
    public GameObject but2;//BOTONES PARA CULTIVAR
    public ItemPickup picka; //ACCEDER A OTRO SCRIPT
    public GameObject obj; //LO QUE IDENTIFICA
    
    public bool siemb=false; //DETECTA QUE LA TIERRA ESTA VACIA Y DEJA PLANTAR
    public bool c1 = false; //TEXTO
    public bool c2 = false;
    public Info info;
    public GameObject Suel1; //SUELO PLANTAR
    public GameObject Suel2;
    public GameObject Suel3;


    private void Awake()
    {
        info=GameObject.FindGameObjectWithTag("Finish").GetComponent<Info>();
        Man=GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
       


        mapa = new Inputmaptest();
        if (info.pat1) //CUANDO SE PLANTA Y SE CAMBIA DE ESCENA
        {
            obj = Instantiate(Pat); //CREA UNA COPIA DEL OBJETO
            //MUEVE LA COPIA AL SUELO SELECCIONADO
            obj.transform.position = new Vector3(GameObject.Find("Suelo").GetComponent<Transform>().position.x, GameObject.Find("Suelo").GetComponent<Transform>().position.y, GameObject.Find("Suelo").GetComponent<Transform>().position.z);
            GameObject.Find("Suelo").GetComponent<Collider>().enabled = false; //DESACTIVA EL COLLIDER PARA NO DETECTAR EL SUELO CUANDO SE PLANTA
            obj.transform.SetParent(GameObject.Find("Suelo").GetComponent<Transform>().transform); //CONVIERTE EL SUELO EN EL PADRE DE LA COPIA
        }
        
        //PARA ACTIVAR MENU
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
        
        //ABRE INVENTARIO
        mapa.Player.interact.performed += hola =>
        {
            if (ishitting)
            {
                //ACTIVAR Y DESACTIVAR INVENTARIO (ENTER)
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

            //ACTIVAR DIALOGOS
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
        
        Ray ray=new Ray(transform.position,transform.forward); //RAYO POSSICION Y ROTACION DEL PERSONAJE
        
        Debug.DrawRay(ray.origin, ray.direction * maxdist, Color.green);

        //ACTIVAR BOTONES DE CULTIVO SEGUN EL INVENTARIO
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
        //COLISION CON EL RAYO DETECTAR
        if (Physics.Raycast(ray, out hit,maxdist))
        {
            //COLISIONA CON DIFERENTES OBJETOS
            if (hit.collider.gameObject.tag=="noobcet") //INVENTARIO
            {
                ishitting = true;
            }
            if (hit.collider.gameObject.tag == "object") //CULTIVABLES
            
            {
                pick = true; //COMPROBAR QUE TOCA EL OBJETO
                picka = hit.collider.gameObject.GetComponent<ItemPickup>(); //DETECTA LO QUE COSECHA
                obj = hit.collider.gameObject.GetComponent<GameObject>();
                
                info.it=hit.collider.gameObject.GetComponent<ItemData>().Item;  

               
                
                

            }
            else
            {
                pick = false;
            }
            if (hit.collider.gameObject.tag=="CAMA")
            {
                dormir = true;
            }
            if (hit.collider.gameObject.tag=="Charac1") //DIALOGO CON PERSONAJE1
            {
                c1=true;
               
               
            }
            
            else if (hit.collider.gameObject.tag == "Charac2") //DIALOGO CON PERSONAJE2
            {
               
               c2 = true;
                
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
        // ABRE EL INVENTARIO
        if (tocar)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            
            if (!image.activeInHierarchy)
            {
                image.SetActive(true);
            }
            Man.Instance.ListItems(); //PONE EL INVENTARIO LOS ICONOS

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
    //ACTIVA EL TEXTO 1
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
        //OBTIENE EL COMPONENTE EN EL HIJO DEL OBJETO GOLPEADO
        texto = hit.collider.gameObject.GetComponentInChildren<TextManager>();
    }

    //ACTIVA EL TEXTO 2
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
        //OBTIENE EL COMPONENTE EN EL HIJO DEL OBJETO GOLPEADO
        texto = hit.collider.gameObject.GetComponentInChildren<TextManager>();
    }

    //PARA SEMBRAR LAS PATATAS
    public void siembraP()
    {
        //SI EL OBJETO GOLPEADO ES SEMBRABLE O NO
        if (hit.collider.gameObject.tag == "Sembrable")
        {
            
            Debug.Log("Golpea");
            //SI NO TIENE NINGÚN HIJO
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
                
                obj.transform.SetParent(hit.collider.gameObject.transform);
                
                siemb = true;






            }
            else
            {
                if (picka)
                {
                   

                    obj.transform.SetParent(null);
                }
            }
        }
    }
}
