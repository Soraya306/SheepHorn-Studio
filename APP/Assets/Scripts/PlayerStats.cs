using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //INFORMACION DEL JUGADOR
    public int Energy;
    public int MaxEnergy;
    public SaveSystem save;
    public PlayerData Data;
    public Vector3 position;
    public void Tired(int tire)
    {
        Energy-=tire;
    }

    public void SavePlayer()
    {
        save.SavePlayer(this);
        }
    public void LoadPlayer()
    {
      
        save.LoadPlayer();
        Data = save.datas;

       
     
        transform.position = position;
    }
}
