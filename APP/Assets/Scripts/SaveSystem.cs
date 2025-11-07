
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.EventSystems;

public class SaveSystem : MonoBehaviour
{
    public PlayerData datas;
    public void SavePlayer(PlayerStats player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.dat";
        FileStream stream = new FileStream(path,FileMode.Create);

       // PlayerData data = new PlayerData(player);
       // formatter.Serialize(stream, data);
        stream.Close();


    }

    public PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player+dat";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);


             datas= formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return datas;
        }
        else
        {
            Debug.Log("save file not found in "+path);
            return null;
        }



    }



}
