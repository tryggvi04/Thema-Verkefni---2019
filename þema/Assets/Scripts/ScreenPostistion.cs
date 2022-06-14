using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPostistion : MonoBehaviour
{
    public float DesiredSize = 60;

    void Start()
    {
      

        float fT = DesiredSize / Screen.width * Screen.height;
        fT = fT / (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad));
        Vector3 v3T = Camera.main.transform.position;
        v3T.z = -fT;
        transform.position = v3T;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
