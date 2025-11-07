using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class PlayerData 
{
    


    [Serializable]
    public struct PlayerDatas
    {
        public float positionx;
        public float positiony;
        public float positionz;


    }


    [SerializeField]
    public PlayerDatas dat;


}
