using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float Enemyhealth;
    public Slider HealthSlider;
    public GameObject slider;
    public float EnemyHealthReal;
    
   
    void Start()
    {
        Damage();
        Enemyhealth = EnemyHealthReal;
    }

    // Update is called once per frame
    void Update()
    {

        Damage();

       
        
    }
    public void Damage()
    {
        HealthSlider.value = Enemyhealth / EnemyHealthReal;
        if (Enemyhealth<= 0)
        {
            Destroy(slider);
           
            

            
            
            Destroy(gameObject);



        }




    }
    

}
