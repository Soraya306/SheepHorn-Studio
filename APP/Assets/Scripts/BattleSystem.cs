using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public enum BattleStates {START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public int Amistad;
    public BattleStates State;
    public TextMeshProUGUI Texts;
    public TMP_Text tes;
    public int Chance;
    public GameObject Accion;
    public GameObject TextBox;
    public GameObject Normal;
    public GameObject Vic;
    public GameObject Der;
    public GameObject ret;
    public Info ju;
    

    private void Start()
    {
        ju = GameObject.FindGameObjectWithTag("Finish").GetComponent<Info>();
        State = BattleStates.START;
        setup();
    }
    public void retu()
    
    {
        ju.cambio = true;
        ju.son1 = true;
        SceneManager.LoadScene(0);
        
       
       
        }

    public void Update()
    {
        if (Amistad >= 100)
        {
            State = BattleStates.WON;
            EndBattle();
        }
        else if (Amistad <= -50)
        {
            State = BattleStates.LOST;
            EndBattle();
        }
    }
    public void setup()
    {
        State = BattleStates.PLAYERTURN;
    }
   
    public void TalkButton()
    {
        
        Accion.SetActive(false);
        TextBox.SetActive(true);

        if (State!=BattleStates.PLAYERTURN)
        return;
       
        StartCoroutine(PlayerTalk());

        

    }

    public void DiscussButton()
    {
        Accion.SetActive(false);
        TextBox.SetActive(true);
        if (State != BattleStates.PLAYERTURN)
            return;

        StartCoroutine(PlayerDiscuss());
        

      
    }

    IEnumerator PlayerTalk()
    {
        Chance = Random.Range(1,10);

       
       
       
        if (Chance<=7)
        {
            Amistad += 10;
            tes.text = "Le gustó lo que dijiste "+" +10";

            
        }
        else
        {
            Amistad -= 5;
            tes.text = "No le gustó mucho "+" -5";
            
        }
            yield return new WaitForSeconds(2f);

       
            Accion.SetActive(true);
        TextBox.SetActive(false);
    }

    public void EndBattle()
    {
        Accion.SetActive(false);
        TextBox.SetActive(true);
        ret.SetActive(true);
        if (State==BattleStates.WON)
        {
            Normal.SetActive(false);
            Vic.SetActive(true);
            tes.text = "Te ganaste su confianza!";
        }else if (State==BattleStates.LOST)
        {
            Normal.SetActive(false);
            Der.SetActive(true);
            tes.text = "No confia en ti aun...";
        }
    }

    IEnumerator PlayerDiscuss()
    {
        Chance = Random.Range(1, 10);




        if (Chance <= 7)
        {
            tes.text = "No le gusto para nada";

            Amistad -= 20;
        }
        else
        {
            tes.text = "Lo apreció bastante!";
            Amistad += 30;
        }
        yield return new WaitForSeconds(2f);
        Accion.SetActive(true);
        TextBox.SetActive(false);

    }
}
