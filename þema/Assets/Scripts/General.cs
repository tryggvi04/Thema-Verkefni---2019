using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public bool Pause;
    public GameObject PauseMenu;
    public GameObject KingSlime;
    public GameObject YouWon;
    public SpriteRenderer Rend;
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (KingSlime == null)
        {
            
            YouWon.SetActive(true);

        }
        if (Input.GetKeyDown("p") && Pause == false)
        {
            Pausevoid();



        }
       

    }

    public void Pausevoid()
    {
        Time.timeScale = 0;
        Pause = true;
        PauseMenu.SetActive(true);


    }
    public void Play()
    {
        if (Pause == true)
        {
            Time.timeScale = 1;
            Pause = false;
            PauseMenu.SetActive(false);
        }
    }
    public void Quit()
    {

        Application.Quit();


    }
    public void Restart()
    {
        Application.LoadLevel("þema");



    }
    
}
