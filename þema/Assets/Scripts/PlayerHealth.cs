using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
 
    public float Health = 100;
    public TextMeshProUGUI HealthText;
    Enemies Enemies;
 
    public float DamageCommon;
    public GameObject Lights;
    Movement movement;
    PlayerAttack Attacks;
    public GameObject GameOver;
    public GameObject HealthText2;
    

    void Start()
    {

        Enemies = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemies>();
        HealthChange();
     
        movement = GetComponent<Movement>();
        Attacks = GetComponent<PlayerAttack>();
    }

   
    void Update()
    {

        AttackHitVoidCommon();
       

    }



    void AttackHitVoidCommon()
    {
      

        if (Health <= 0)
        {
            GameOver.SetActive(true);
            HealthText2.SetActive(false);
            Destroy(movement);
            

        }

    }
    public void HealthChange()
    {
        
        HealthText.text = ("Health: ") + Health.ToString();



    }
}
