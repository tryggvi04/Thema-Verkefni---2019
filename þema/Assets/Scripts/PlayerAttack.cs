using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public float AttackDamage;
    EnemyHealth Enemy;
    public Transform AttackStart;
    public bool Attack;
    public float Cooldown;
    public float CooldownR;
    public Transform[] AttackEnd;
    public int Direction;
    PlayerHealth Health;
    public float CollisionDamage;
    public float CollisionDamageReal;
    public TextMeshProUGUI AttackCountdown;
    public GameObject AttackcountdownG;
    public Animator Ani;
    public SpriteRenderer Player;
    public float WaitTime;
    public bool WaitTimeB;

    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        
        Health = GetComponent<PlayerHealth>();
        CollisionDamage = CollisionDamageReal;
    }

    
    void Update()
    {
        if (WaitTimeB==true){

            AttackAnimation();

        }
        if (CooldownR <= 0)
        {
            AttackcountdownG.SetActive(false);


        }

        if (CooldownR >= 0.1f)
        {
            AttackcountdownG.SetActive(true);


        }
        AttackCountdown.text = CooldownR.ToString("0");
        AttackDirection();
      
        Debug.DrawLine(AttackStart.position, AttackEnd[Direction].position, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            if (CooldownR <= 0)
            {
                Attack = true;



            }
           




        }
        if (CooldownR >= 0)
        {
            CooldownR -= Time.deltaTime;




        }
        
        if (Attack == true)
        {

            Damage();
          

        }

    }
    void AttackAnimation()
    {
        
        if (WaitTime >= 0)
        {



            if (Direction == 1)
            {
                Ani.SetBool("BackAttack", false);
                Ani.SetBool("SideWaysAttack", true);
                Ani.SetBool("FrontAttack", false);
                Player.flipX = false;

            }
            if (Direction == 2)
            {
                Ani.SetBool("BackAttack", false);
                Ani.SetBool("SideWaysAttack", false);
                Ani.SetBool("FrontAttack", true);
                Player.flipX = false;

            }
            if (Direction == 3)
            {
                Ani.SetBool("BackAttack", true);
                Ani.SetBool("SideWaysAttack", false);
                Ani.SetBool("FrontAttack", false);
                Player.flipX = false;

            }
            if (Direction == 0)
            {
                Ani.SetBool("BackAttack", false);
                Ani.SetBool("SideWaysAttack", true);
                Ani.SetBool("FrontAttack", false);
                Player.flipX = true;


            }
        }
        
        WaitTime -= Time.deltaTime;
        if (WaitTime <= 0)
        {
            Ani.SetBool("BackAttack", false);
            Ani.SetBool("SideWaysAttack", false);
            Ani.SetBool("FrontAttack", false);
            Player.flipX = false;
            WaitTimeB = false;

        }
      
    }
    void Damage()
    {
        WaitTime = 0.4333f;
        WaitTimeB = true;
        CooldownR = Cooldown;
        RaycastHit2D hit; 
            hit = Physics2D.Linecast(AttackStart.position, AttackEnd[Direction].position, 1 << LayerMask.NameToLayer("Enemy"));
        
        if (hit.collider != null)
        {
            hit.collider.GetComponent<EnemyHealth>().Enemyhealth -= AttackDamage; 
            
            

        }
        Attack = false;
     
        Player.flipX = true;

    }
    void AttackDirection()
    {
        
        if (Input.GetKey("w") )
        {

           
                Direction = 3;
          
        }
        if (Input.GetKey("s"))
        {
            

                Direction = 2;

            


        }
        if (Input.GetKey("a"))
        {
           
                Direction = 1;
            


        }
        if (Input.GetKey("d"))
        {

                Direction = 0;
            
           



        }
       

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (CollisionDamage >= CollisionDamageReal)
        {
            if (other.CompareTag("Enemy"))
            {
                if (Direction == 0)
                {

                    transform.position = AttackEnd[1].position;
                    Health.Health -= 5f;
                    Health.HealthChange();

                }
                if (Direction == 1)
                {

                    gameObject.transform.position = AttackEnd[0].position;
                    Health.Health -= 5f;
                    Health.HealthChange();

                }
                if (Direction == 3)
                {

                    transform.position = AttackEnd[2].position;
                    Health.Health -= 5f;
                    Health.HealthChange();

                }
                if (Direction == 2)
                {

                    transform.position = AttackEnd[3].position;
                    Health.Health -= 5f;
                    Health.HealthChange();

                }
               
                CollisionDamage = 0;
            }
           
        }
        else
        {
            CollisionDamage += Time.deltaTime;

        }
    }
}
