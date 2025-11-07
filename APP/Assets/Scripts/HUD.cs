using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //SISTEMA DE ENERGIA
    public Slider EnergySlide;
   public void HUDSetup(PlayerStats Object)
    {
        EnergySlide.maxValue=Object.MaxEnergy;
        EnergySlide.value=Object.Energy;
    }
    public void SetEnergy(int EN)
    {
        EnergySlide.value = EN;
    }
}
