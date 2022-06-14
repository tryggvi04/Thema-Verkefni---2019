using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform sightStart, sighEnd;
    public bool Spotted;
    public bool HeardYouBaka;
    public float Distances;
    public Vector2 Origin;
   
    public bool AttackHit;
    Enemies Enemy;

  void Start()
    {
        Origin = gameObject.transform.position;
        Enemy = GetComponent<Enemies>();
    }
    void Update()
    {
        
        Raycasting();
        Origin = gameObject.transform.position;
    }
    void Raycasting()
    {
       
        Spotted = Physics2D.Linecast(sightStart.position, sighEnd.position , 1 << LayerMask.NameToLayer("Player"));
       
     


        if (Spotted == true)
        {


        }
      
        
    }



    




}

