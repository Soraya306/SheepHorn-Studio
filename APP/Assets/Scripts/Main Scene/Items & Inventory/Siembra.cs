using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Siembra : MonoBehaviour
{
    [Header("Scripts")]
    public RaycastSystem Ray;
   
    public InfoBetweenScenes Info;

    private void Awake()
    {
        Info = GameObject.Find("GameManager").GetComponent<InfoBetweenScenes>();
        ResiembraP();
        
    }

    public void SiembraP()
    {
       
        if (Ray.Hit.collider.gameObject.tag=="Tierras")
        {
            if (Ray.Hit.collider.gameObject.transform.childCount==0)
            {
                

                for(int i = 0; i <= InventoryManager.Instance.Items.Count; i++)
                {
                    int ID = InventoryManager.Instance.Items[i].Item.id;
                    if(ID == 2)
                    {
                        InventoryManager.Instance.Items.Remove(InventoryManager.Instance.Items[i]);
                        break;
                    }
                }
                Ray.id2--;
                

                if (Ray.Hit.collider.gameObject.name==Ray.Tierra1.name)
                {
                    Ray.OBJ = Instantiate(Ray.Patatas);
                    Ray.OBJ.transform.position=Ray.Tierra1.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra1.GetComponent<Transform>().transform);
                    Ray.Tierra1.GetComponent<Collider>().enabled = false;
                    Info.TP1 = true;
                    

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra2.name)
                {
                    Ray.OBJ = Instantiate(Ray.Patatas);
                    Ray.OBJ.transform.position = Ray.Tierra2.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra2.GetComponent<Transform>().transform);
                    Ray.Tierra2.GetComponent<Collider>().enabled = false;
                    Info.TP2 = true;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra3.name)
                {
                    Ray.OBJ = Instantiate(Ray.Patatas);
                    Ray.OBJ.transform.position = Ray.Tierra3.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra3.GetComponent<Transform>().transform);
                    Ray.Tierra3.GetComponent<Collider>().enabled = false;
                    Info.TP3 = true;


                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra4.name)
                {
                    Ray.OBJ = Instantiate(Ray.Patatas);
                    Ray.OBJ.transform.position = Ray.Tierra4.transform.position;
                    Ray.Tierra4.transform.SetParent(Ray.Tierra4.GetComponent<Transform>().transform);
                    Ray.Tierra4.GetComponent<Collider>().enabled = false;
                    Info.TP4 = true;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra5.name)
                {
                    Ray.OBJ = Instantiate(Ray.Patatas);
                    Ray.OBJ.transform.position = Ray.Tierra5.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra5.GetComponent<Transform>().transform);
                    Ray.Tierra5.GetComponent<Collider>().enabled = false;
                    Info.TP5 = true;
                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra6.name)
                {
                    Ray.OBJ = Instantiate(Ray.Patatas);
                    Ray.OBJ.transform.position = Ray.Tierra6.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra6.GetComponent<Transform>().transform);
                    Ray.Tierra6.GetComponent<Collider>().enabled = false;
                    Info.TP6 = true;
                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra7.name)
                {
                    Ray.OBJ = Instantiate(Ray.Patatas);
                    Ray.OBJ.transform.position = Ray.Tierra7.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra7.GetComponent<Transform>().transform);
                    Ray.Tierra7.GetComponent<Collider>().enabled = false;
                    Info.TP7 = true;
                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra8.name)
                {
                    Ray.OBJ = Instantiate(Ray.Patatas);
                    Ray.OBJ.transform.position = Ray.Tierra8.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra8.GetComponent<Transform>().transform);
                    Ray.Tierra8.GetComponent<Collider>().enabled = false;
                    Info.TP8 = true;
                }
            }
        }
    }
    public void SiembraF()
    {
        if (Ray.Hit.collider.gameObject.tag == "Tierras")
        {
            if (Ray.Hit.collider.gameObject.transform.childCount == 0)
            {
                for (int i = 0; i <= InventoryManager.Instance.Items.Count; i++)
                {
                    int ID = InventoryManager.Instance.Items[i].Item.id;
                    if (ID == 1)
                    {
                        InventoryManager.Instance.Items.Remove(InventoryManager.Instance.Items[i]);
                        break;
                    }
                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra1.name)
                {
                    Ray.OBJ = Instantiate(Ray.Fresas);
                    Ray.OBJ.transform.position = Ray.Tierra1.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra1.GetComponent<Transform>().transform);
                    Ray.Tierra1.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra2.name)
                {
                    Ray.OBJ = Instantiate(Ray.Fresas);
                    Ray.OBJ.transform.position = Ray.Tierra2.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra2.GetComponent<Transform>().transform);
                    Ray.Tierra2.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra3.name)
                {
                    Ray.OBJ = Instantiate(Ray.Fresas);
                    Ray.OBJ.transform.position = Ray.Tierra3.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra3.GetComponent<Transform>().transform);
                    Ray.Tierra3.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra4.name)
                {
                    Ray.OBJ = Instantiate(Ray.Fresas);
                    Ray.OBJ.transform.position = Ray.Tierra4.transform.position;
                    Ray.Tierra4.transform.SetParent(Ray.Tierra4.GetComponent<Transform>().transform);
                    Ray.Tierra4.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra5.name)
                {
                    Ray.OBJ = Instantiate(Ray.Fresas);
                    Ray.OBJ.transform.position = Ray.Tierra5.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra5.GetComponent<Transform>().transform);
                    Ray.Tierra5.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra6.name)
                {
                    Ray.OBJ = Instantiate(Ray.Fresas);
                    Ray.OBJ.transform.position = Ray.Tierra6.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra6.GetComponent<Transform>().transform);
                    Ray.Tierra6.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra7.name)
                {
                    Ray.OBJ = Instantiate(Ray.Fresas);
                    Ray.OBJ.transform.position = Ray.Tierra7.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra7.GetComponent<Transform>().transform);
                    Ray.Tierra7.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra8.name)
                {
                    Ray.OBJ = Instantiate(Ray.Fresas);
                    Ray.OBJ.transform.position = Ray.Tierra8.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra8.GetComponent<Transform>().transform);
                    Ray.Tierra8.GetComponent<Collider>().enabled = false;

                }
            }
        }
    }
    public void SiembraT()
    {
        if (Ray.Hit.collider.gameObject.tag == "Tierras")
        {
            if (Ray.Hit.collider.gameObject.transform.childCount == 0)
            {
                for (int i = 0; i <= InventoryManager.Instance.Items.Count; i++)
                {
                    int ID = InventoryManager.Instance.Items[i].Item.id;
                    if (ID == 3)
                    {
                        InventoryManager.Instance.Items.Remove(InventoryManager.Instance.Items[i]);
                        break;
                    }
                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra1.name)
                {
                    Ray.OBJ = Instantiate(Ray.Tomates);
                    Ray.OBJ.transform.position = Ray.Tierra1.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra1.GetComponent<Transform>().transform);
                    Ray.Tierra1.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra2.name)
                {
                    Ray.OBJ = Instantiate(Ray.Tomates);
                    Ray.OBJ.transform.position = Ray.Tierra2.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra2.GetComponent<Transform>().transform);
                    Ray.Tierra2.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra3.name)
                {
                    Ray.OBJ = Instantiate(Ray.Tomates);
                    Ray.OBJ.transform.position = Ray.Tierra3.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra3.GetComponent<Transform>().transform);
                    Ray.Tierra3.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra4.name)
                {
                    Ray.OBJ = Instantiate(Ray.Tomates);
                    Ray.OBJ.transform.position = Ray.Tierra4.transform.position;
                    Ray.Tierra4.transform.SetParent(Ray.Tierra4.GetComponent<Transform>().transform);
                    Ray.Tierra4.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra5.name)
                {
                    Ray.OBJ = Instantiate(Ray.Tomates);
                    Ray.OBJ.transform.position = Ray.Tierra5.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra5.GetComponent<Transform>().transform);
                    Ray.Tierra5.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra6.name)
                {
                    Ray.OBJ = Instantiate(Ray.Tomates);
                    Ray.OBJ.transform.position = Ray.Tierra6.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra6.GetComponent<Transform>().transform);
                    Ray.Tierra6.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra7.name)
                {
                    Ray.OBJ = Instantiate(Ray.Tomates);
                    Ray.OBJ.transform.position = Ray.Tierra7.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra7.GetComponent<Transform>().transform);
                    Ray.Tierra7.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra8.name)
                {
                    Ray.OBJ = Instantiate(Ray.Tomates);
                    Ray.OBJ.transform.position = Ray.Tierra8.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra8.GetComponent<Transform>().transform);
                    Ray.Tierra8.GetComponent<Collider>().enabled = false;

                }
            }
        }
    }
    public void SiembraS()
    {
        if (Ray.Hit.collider.gameObject.tag == "Tierras")
        {
            if (Ray.Hit.collider.gameObject.transform.childCount == 0)
            {
                for (int i = 0; i <= InventoryManager.Instance.Items.Count; i++)
                {
                    int ID = InventoryManager.Instance.Items[i].Item.id;
                    if (ID == 4)
                    {
                        InventoryManager.Instance.Items.Remove(InventoryManager.Instance.Items[i]);
                        break;
                    }
                }

                if (Ray.Hit.collider.gameObject.name == Ray.Tierra1.name)
                {
                    Ray.OBJ = Instantiate(Ray.Sandias);
                    Ray.OBJ.transform.position = Ray.Tierra1.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra1.GetComponent<Transform>().transform);
                    Ray.Tierra1.GetComponent<Collider>().enabled = false;


                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra2.name)
                {
                    Ray.OBJ = Instantiate(Ray.Sandias);
                    Ray.OBJ.transform.position = Ray.Tierra2.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra2.GetComponent<Transform>().transform);
                    Ray.Tierra2.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra3.name)
                {
                    Ray.OBJ = Instantiate(Ray.Sandias);
                    Ray.OBJ.transform.position = Ray.Tierra3.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra3.GetComponent<Transform>().transform);
                    Ray.Tierra3.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra4.name)
                {
                    Ray.OBJ = Instantiate(Ray.Sandias);
                    Ray.OBJ.transform.position = Ray.Tierra4.transform.position;
                    Ray.Tierra4.transform.SetParent(Ray.Tierra4.GetComponent<Transform>().transform);
                    Ray.Tierra4.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra5.name)
                {
                    Ray.OBJ = Instantiate(Ray.Sandias);
                    Ray.OBJ.transform.position = Ray.Tierra5.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra5.GetComponent<Transform>().transform);
                    Ray.Tierra5.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra6.name)
                {
                    Ray.OBJ = Instantiate(Ray.Sandias);
                    Ray.OBJ.transform.position = Ray.Tierra6.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra6.GetComponent<Transform>().transform);
                    Ray.Tierra6.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra7.name)
                {
                    Ray.OBJ = Instantiate(Ray.Sandias);
                    Ray.OBJ.transform.position = Ray.Tierra7.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra7.GetComponent<Transform>().transform);
                    Ray.Tierra7.GetComponent<Collider>().enabled = false;

                }
                if (Ray.Hit.collider.gameObject.name == Ray.Tierra8.name)
                {
                    Ray.OBJ = Instantiate(Ray.Sandias);
                    Ray.OBJ.transform.position = Ray.Tierra8.transform.position;
                    Ray.OBJ.transform.SetParent(Ray.Tierra8.GetComponent<Transform>().transform);
                    Ray.Tierra8.GetComponent<Collider>().enabled = false;

                }
            }
        }
    }

    public void ResiembraP()
    {
        if (Info.TP1)
        {
            Ray.OBJ = Instantiate(Ray.Patatas);
            Ray.OBJ.transform.position = Ray.Tierra1.transform.position;
            Ray.OBJ.transform.SetParent(Ray.Tierra1.GetComponent<Transform>().transform);
        }
        if (Info.TP2)
        {
            Ray.OBJ = Instantiate(Ray.Patatas);
            Ray.OBJ.transform.position = Ray.Tierra2.transform.position;
            Ray.OBJ.transform.SetParent(Ray.Tierra2.GetComponent<Transform>().transform);
        }
        if (Info.TP3)
        {
            Ray.OBJ = Instantiate(Ray.Patatas);
            Ray.OBJ.transform.position = Ray.Tierra3.transform.position;
            Ray.OBJ.transform.SetParent(Ray.Tierra3.GetComponent<Transform>().transform);
        }
        if (Info.TP4)
        {
            Ray.OBJ = Instantiate(Ray.Patatas);
            Ray.OBJ.transform.position = Ray.Tierra4.transform.position;
            Ray.Tierra4.transform.SetParent(Ray.Tierra4.GetComponent<Transform>().transform);
        }
        if (Info.TP5)
        {
            Ray.OBJ = Instantiate(Ray.Patatas);
            Ray.OBJ.transform.position = Ray.Tierra5.transform.position;
            Ray.OBJ.transform.SetParent(Ray.Tierra5.GetComponent<Transform>().transform);
        }
        if (Info.TP6)
        {
            Ray.OBJ = Instantiate(Ray.Patatas);
            Ray.OBJ.transform.position = Ray.Tierra6.transform.position;
            Ray.OBJ.transform.SetParent(Ray.Tierra6.GetComponent<Transform>().transform);
        }
        if (Info.TP7)
        {
            Ray.OBJ = Instantiate(Ray.Patatas);
            Ray.OBJ.transform.position = Ray.Tierra7.transform.position;
            Ray.OBJ.transform.SetParent(Ray.Tierra7.GetComponent<Transform>().transform);
        }
        if (Info.TP8)
        {
            Ray.OBJ = Instantiate(Ray.Patatas);
            Ray.OBJ.transform.position = Ray.Tierra8.transform.position;
            Ray.OBJ.transform.SetParent(Ray.Tierra8.GetComponent<Transform>().transform);
        }
    }
}
