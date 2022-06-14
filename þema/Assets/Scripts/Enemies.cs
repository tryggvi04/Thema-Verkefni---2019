using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Enemies : MonoBehaviour
{
    public Transform[] MoveSpots;
    public float WaitTime;
    public float WaitTimeReal;
    public float Speed;
    Vector3 Rotation;
    public int Directions;
    Rigidbody2D Rb;
    public GameObject End;
    GameObject Player;
    RayCast AttackHit;
   public bool Attack;
    public bool Still;
    public Animator Walking;
    public float WaitTimeTime;
    public bool WaitTimeB;
    public bool AttackStart;
    bool Move;
    PlayerHealth playerHealth;
    bool AttackStop;
    Vector3 Angles;
    public float WaitTimeAttack;
    public float WaitTimeRealAttack;
    public bool KingSlime;
    public GameObject Text;
    public float KingSlimeDamage;
    

    void Start()
    {
        if (KingSlime == true) { 
            Text.SetActive(false);

        }
        WaitTimeAttack = WaitTimeRealAttack;
        Walking = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        WaitTimeReal = WaitTime;
        Directions = 1;
        Rb = gameObject.GetComponent<Rigidbody2D>();
        AttackHit = GetComponent<RayCast>();
        Angles = new Vector3(1, 1, 0);
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }


    void Update()
    {
        SeePlayer();
        if (WaitTimeB == true)
        {
            AttackAnimation();

        }
        
        if (Attack == true)
        {
            if (AttackStop == false)
            {
                Walking.SetBool("Angry", true);

            }
            SeePlayerRegular();
            

        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.Rotate(transform.rotation.x, transform.rotation.y, 0);
        if (Attack == false)
        {
            Patrol();
        }
        if (Still == true)
        {
            if (Attack == false)
            {
                Walking.SetFloat("Speed", 0);


            }



        }
        if (Still == false)
        {
            if (AttackHit.Spotted == true)
            {
                Attack = true;



            }
        }
       
    }
    void AttackAnimation()
    {

        if (WaitTimeTime >= 0)
        {
            Walking.SetBool("AttackAngry", true);



        }
            WaitTimeTime -= Time.deltaTime;
            if (WaitTimeTime <= 0)
            {
                Walking.SetBool("AttackAngry", false);
                WaitTimeB = false;
            }

        
    }
    void Patrol()
    {
        if (Still == false)
        {
            End.transform.position = MoveSpots[Directions].position;

            if (Vector2.Distance(transform.position, MoveSpots[Directions].position) < 2f)
            {

                if (Directions == 3)
                {

                    Directions = -1;



                }
                Directions += 1;
                End.transform.Translate(MoveSpots[Directions].position);
            }

            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) <= 7f && KingSlime == false)
            {
                Attack = true;




            }
           
        }
        if (Still == true)
        {
            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) <= 10f && KingSlime == false)
            {
                Attack = true;




            }
            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) <= 70f && KingSlime == true)
            {
                Attack = true;




            }

        }

    }
    void PatrolMovement()
    {
        if (Still == false)
        {
            if (Attack == false)
            {

                Rb.MovePosition(Vector3.MoveTowards(transform.position, MoveSpots[Directions].position, Speed * Time.fixedDeltaTime));
                Walking.SetFloat("Speed", 1);
            }
        }
    }

    void SeePlayerRegular()
    {
        Text.SetActive(true);
        if (Vector2.Distance(transform.position, Player.transform.position) >= 25f && KingSlime==false)
        {
            Text.SetActive(false);
            Walking.SetFloat("Speed", 0);
            Attack = false;
          
        }
            if (Vector2.Distance(transform.position, Player.transform.position) <= 4f)
            {
                Move = true;



            }
            if (Vector2.Distance(transform.position, Player.transform.position) >= 4f)
            {
                Move = false;



            }
            if (Move == true)
            {
                Rb.constraints = RigidbodyConstraints2D.FreezeAll;
                Walking.SetFloat("Speed", 0);
            AttackStop = true;       
            Walking.SetBool("Angry", false);
            Walking.SetBool("AngryIdle", true);
        }

            if (Move == false)
            {
                Walking.SetFloat("Speed", 1);
            AttackStop = false;
                Rb.constraints = RigidbodyConstraints2D.None;
            Walking.SetBool("AngryIdle", false);
        }

        




    }
    void SeePlayer()
    {
        if (Attack == true)
        {
          

            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) <= 5f && KingSlime == false)
            {
                AttackStart = true;
              


            }
            
            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) <= 5f && KingSlime == true)
            {
                AttackStart = true;



            }
          if (Vector2.Distance(gameObject.transform.position, Player.transform.position) >= 5f && KingSlime == false)
            {
                AttackStart = false;
              


            }
            
            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) >= 5f && KingSlime == true)
            {
                AttackStart = false;



            }


            Rb.MovePosition(Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.fixedDeltaTime));
            Walking.SetFloat("Speed", 1);


            
            

        }
        if (AttackStart == true)
        {


            if (WaitTimeAttack >= WaitTimeRealAttack)
            {
                if (KingSlime == true)
                {

                    playerHealth.Health -= KingSlimeDamage;

                }
                else
                {
                    playerHealth.Health -= playerHealth.DamageCommon;
                }
                    WaitTimeAttack = 0;
               playerHealth.HealthChange();
                WaitTimeB = true;
               WaitTimeTime = 0.517f;
               
            }
            else
            {
               WaitTimeAttack += Time.deltaTime;

            }
        }

    }
    void FixedUpdate()
    {
        SeePlayer();
        if (Attack == false)
        {
            PatrolMovement();
        }
        }
}
