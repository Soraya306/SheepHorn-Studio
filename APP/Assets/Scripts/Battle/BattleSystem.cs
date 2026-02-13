using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum States { START, PLAYER, WON, LOST}
public class BattleSystem : MonoBehaviour
{

    [Header("Datos")]
    public int Amistad;
    public int Porcentaje;
    public int Index;
    public TextMeshProUGUI Texto;
    public States BStates;
    public string[] Lines;
    public int porcentaje_hablar;
    public int porcentaje_discutir;
    public InfoBetweenScenes info;
    

    [Header("Objetos")]
    public GameObject Return_Button;
    public GameObject Accion_Buttons;
    public GameObject Text_Box;
    public GameObject Neutro;
    public GameObject Respuesta_Pos;
    public GameObject Respuesta_Neg;
    public GameObject Victoria;
    public GameObject Derrota;

    private void Start()
    {
        info = GameObject.Find("GameManager").GetComponent<InfoBetweenScenes>();
        BStates=States.START;
        Texto.text=string.Empty;
        Setup();
    }

    private void Update()
    {
        if (info.dificultad_cerdo)
        {
            batalla_cerdo();
            info.posicioncerdo = true;
        }

        if (info.dificultad_vaca)
        {
            batalla_vaca();
            info.posicionvaca = true;
        }
        if (info.dificultad_gallina)
        {
            batalla_gallina();
            info.posiciongallina = true;
        }

        if (Amistad>=100)
        {
            BStates=States.WON;
            StopAllCoroutines();
            EndBattle();
        }else if (Amistad<=-50)
        {
            BStates=States.LOST;
            StopAllCoroutines();
            EndBattle();

        }
    }

    public void Setup()
    {
        BStates=States.PLAYER;
    }

    public void TalkButton()
    {
        Accion_Buttons.SetActive(false);
        Text_Box.SetActive(true);

        if (BStates!=States.PLAYER)
            return;

        StartCoroutine(PlayerTalk());
 
    }

    public void DiscussButton()
    {
        Accion_Buttons.SetActive(false);
        Text_Box.SetActive(true);
        if (BStates != States.PLAYER)
            return;

        StartCoroutine(PlayerDiscuss());
    }

    public void EndBattle()
    {
        Accion_Buttons.SetActive(false);
        Text_Box.SetActive(true);
        if (BStates==States.WON)
        {
            Neutro.SetActive(false);
           
            Respuesta_Pos.SetActive(false);
            Respuesta_Neg.SetActive(false);
            Return_Button.SetActive(true);
            Victoria.SetActive(true);
            Texto.text = Lines[4];

        }else if (BStates==States.LOST)
        {
            Neutro.SetActive(false);
            
            Respuesta_Pos.SetActive(false);
            Respuesta_Neg.SetActive(false);
            Return_Button.SetActive(true);
            Derrota.SetActive(true);
            Texto.text= Lines[5];
        }
    }

    public void Retornocerdo()
    {
        info.cerdobatallaactiva = false;
        info.change = true;
        SceneManager.LoadScene(5);
    }
    public void Retornovaca()
    {
        info.vacabatallaactiva= false;
        info.change = true;
        SceneManager.LoadScene(4);
    }
    public void RetornoGallina()
    {
        info.gallinabatallaactiva = false;
        info.change = true;
        SceneManager.LoadScene(3);
    }
    public void retornocarnero()
    {
        info.carnerobatalla = true;
        info.change = true;
        info.carnero = false;
        SceneManager.LoadScene(1);
    }
    IEnumerator PlayerTalk()
    {
        Porcentaje = Random.Range(1,10);

        if (Porcentaje<=7)
        {
            Amistad += 10;
            Texto.text = Lines[0];
            Neutro.SetActive(false);
            Respuesta_Pos.SetActive(true);
        }
        else
        {
            Amistad -= 5;
            Texto.text = Lines[1];
            Neutro.SetActive(false);
            Respuesta_Neg.SetActive(true);
        }

        yield return new WaitForSeconds(1f);
        
        Accion_Buttons.SetActive(true);
        Text_Box.SetActive(false);
        Neutro.SetActive (true);
        Respuesta_Pos.SetActive (false);
        Respuesta_Neg.SetActive (false);
        
    }

    IEnumerator PlayerDiscuss()
    {
        Porcentaje = Random.Range(1, 10);

        if (Porcentaje <= 7)
        {
            Amistad -= 20;
            Texto.text= Lines[2];
            Neutro.SetActive(false);
            Respuesta_Neg.SetActive(true);
        }
        else
        {
            Amistad += 30;
            Texto.text = Lines[3];
            Neutro.SetActive(false);
            Respuesta_Pos.SetActive(true);
        }

        yield return new WaitForSeconds(1f);
        
        Accion_Buttons.SetActive(true);
        Text_Box.SetActive(false);
        Neutro.SetActive(true);
        Respuesta_Pos.SetActive(false);
        Respuesta_Neg.SetActive(false);
    }
    public void batalla_cerdo()
    {
        porcentaje_hablar = 5;
        porcentaje_discutir = 6;

    }
    public void batalla_vaca()
    {
        porcentaje_hablar = 6;
        porcentaje_discutir = 7;

    }
    public void batalla_gallina()
    {
        porcentaje_hablar = 4;
        porcentaje_discutir = 8;
    }




}




