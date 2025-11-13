using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataSaver : MonoBehaviour
{
    
    public int what = 0;
    public GameObject obj;
    public PlayerData puro_data;
    public Info inf;
    

    private void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
        obj.transform.position = new Vector3(inf.posx, inf.posy, inf.posz); //PONE EN LA POSICION
        
        inf.cambio = false;
        
        
    }
    
    public void Save()
    {
        //NO TOCAR
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MyGameData.dat");

         puro_data= new PlayerData();
        //DATOS A GUARDAR
        puro_data.dat.positionx=obj.transform.position.x;
        puro_data.dat.positiony=obj.transform.position.y;
        puro_data.dat.positionz=obj.transform.position.z;
      
        //EL GUARDADO
        bf.Serialize(file, puro_data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/MyGameData.dat"))
        {
            //CARGA EL SAVE
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/MyGameData.dat", FileMode.Open);
            PlayerData puro_data = bf.Deserialize(fs) as PlayerData;
            fs.Close();

            if (puro_data != null)
            {
               

                obj.GetComponent<CharacterController>().enabled = false;
                obj.transform.position = new Vector3(puro_data.dat.positionx,puro_data.dat.positiony,puro_data.dat.positionz);
                obj.GetComponent<CharacterController>().enabled = true;
            }
        }
    }
    private void Update()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
    }
}
