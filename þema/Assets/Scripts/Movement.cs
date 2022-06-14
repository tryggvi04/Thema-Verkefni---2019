using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class Movement : MonoBehaviour
{
    Vector2 Dodge;
    public float Speed = 5f;
    public Rigidbody2D Rb;
    public Vector2 MovementV;
    public float WaitTime;
    public float WaitTimeReal;
    public bool canIDodge;
    public Vector2 Dodge1;
    public Slider DodgeCooldown;
   public SpriteRenderer Player;
   Animator Ani;
    float MoveVertical;
    float MoveHorizontal;
    float DodgeWait;
    


    // Start is called before the first frame update
    void Start()
    {
        Dodge = new Vector2(50, 0);
        Rb = gameObject.GetComponent<Rigidbody2D>();
        WaitTimeReal = WaitTime;
        Dodge1 = new Vector2(0, 50);
        new Vector2(0, -Speed);
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationDodge();
        Slider();
        MoveVertical =  Input.GetAxisRaw("Vertical") * Speed;
     
        MoveHorizontal = Input.GetAxisRaw("Horizontal") * Speed;
        Ani.SetFloat("Speed", Mathf.Abs(MoveVertical) + Mathf.Abs(MoveHorizontal));
        MovementVoid();

    }


    private void FixedUpdate()
    {
        
        DodgeVoid();
    }





    void MovementVoid()
    {
        if (Input.GetKey("s"))
        {
           
            Rb.MovePosition((Vector2)transform.position + (Speed * Time.fixedDeltaTime * new Vector2(0, -1)));
            Ani.SetBool("WalkingFront", true);
            Ani.SetBool("WalkingBack", false);
            Ani.SetBool("WalkingRight", false);
            Ani.SetBool("WalkingLeft", false);
            Player.flipX = false;
        }
        if (Input.GetKey("w"))
        {
           
            Rb.MovePosition((Vector2)transform.position + (Speed * Time.fixedDeltaTime * new Vector2(0, 1)));
            Ani.SetBool("WalkingBack", true);
            Ani.SetBool("WalkingFront", false);
            Ani.SetBool("WalkingRight", false);
            Ani.SetBool("WalkingLeft", false);
            Player.flipX = false;
        }
        if (Input.GetKey("a"))
        {
           
            Rb.MovePosition((Vector2)transform.position + (Speed * Time.fixedDeltaTime * new Vector2(-1, 0)));
            Ani.SetBool("WalkingRight", false);
            Ani.SetBool("WalkingBack", false);
            Ani.SetBool("WalkingFront", false);
            Ani.SetBool("WalkingLeft", true);
            Player.flipX = false;
        }
        if (Input.GetKey("d"))
        {
            
            Rb.MovePosition((Vector2)transform.position + (Speed * Time.fixedDeltaTime * new Vector2(1, 0)));
            Ani.SetBool("WalkingRight", true);
            Ani.SetBool("WalkingBack", false);
            Ani.SetBool("WalkingFront", false);
            Ani.SetBool("WalkingLeft", false);
            Player.flipX = true;

        }







        if (Input.GetKeyUp("w"))
        {
            Ani.SetBool("IdleBack", true);
            Ani.SetBool("idleFront", false);
              Ani.SetBool("IdleLeft", false);
            Ani.SetBool("idleRight", false);
            Player.flipX = false;
        }
        if (Input.GetKeyUp("s"))
        {
            Ani.SetBool("IdleBack", false);
            Ani.SetBool("idleFront", true);
            Ani.SetBool("IdleLeft", false);
            Ani.SetBool("idleRight", false);

            Player.flipX = false;
        }
        if (Input.GetKeyUp("d"))
        {
            Ani.SetBool("IdleLeft", false);
            Ani.SetBool("idleRight", true);
            Ani.SetBool("IdleBack", false);
            Ani.SetBool("idleFront", false);
            Player.flipX = true;
        }
        if (Input.GetKeyUp("a"))
        {
            Ani.SetBool("IdleLeft", true);
            Ani.SetBool("idleRight", false);
            Ani.SetBool("IdleBack", false);
            Ani.SetBool("idleFront", false);
            Player.flipX = false;
        }
    }






    void DodgeVoid()
    {
        if (canIDodge == true)
        {
            WaitTimeReal -= Time.deltaTime;
            if (WaitTimeReal <= 0)
            {
                WaitTimeReal = WaitTime;
                canIDodge = false;



            }



        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d"))
        {



            if (WaitTimeReal == WaitTime)
            {
                DodgeWait = 0.183f;

                Rb.MovePosition((Vector2)transform.position + (Dodge * Speed * Time.fixedDeltaTime));
                Ani.SetBool("DodgeSideways", true);
                Player.flipX = true;
                canIDodge = true;
            }


        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a"))
        {



            if (WaitTimeReal == WaitTime)
            {
                DodgeWait = 0.183f;
                Rb.MovePosition((Vector2)transform.position + (-Dodge * Speed * Time.fixedDeltaTime));
                Ani.SetBool("DodgeSideways", true);
                canIDodge = true;
            }


        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {



            if (WaitTimeReal == WaitTime)
            {
                DodgeWait = 0.183f;
                Rb.MovePosition((Vector2)transform.position + (Dodge1 * Speed * Time.fixedDeltaTime));
                Ani.SetBool("DodgeBack", true);

                canIDodge = true;
            }


        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("s"))
        {



            if (WaitTimeReal == WaitTime)
            {
                DodgeWait = 0.183f;
                Rb.MovePosition((Vector2)transform.position + (-Dodge1 * Speed * Time.fixedDeltaTime));
                Ani.SetBool("DodgeFront", true);
                canIDodge = true;
            }


        }



    }
    void Slider()
    {
        DodgeCooldown.value = WaitTimeReal / WaitTime;




    }
    void AnimationDodge()
    {
       
        if (Ani.GetBool("DodgeFront") == true || Ani.GetBool("DodgeBack") == true || Ani.GetBool("DodgeSideways") == true) 
        {
           
            DodgeWait -= Time.deltaTime;
            if ( DodgeWait <= 0)
            {
                Ani.SetBool("DodgeFront", false);
                    Ani.SetBool("DodgeBack", false);

                Ani.SetBool("DodgeSideways", false);



            }


        }



    }
}