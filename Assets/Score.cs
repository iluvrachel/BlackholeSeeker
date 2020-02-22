using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private Vector2 dis_error;
    private int score;
    public Text[] text;
    public static int level = 0;
    private int win_flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        text[1].text = "LEVEL: " + level.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            level = 0;
            RestartScene();
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && win_flag == 1)
        {
            NextScene();
        }
        
        


        if (Input.GetMouseButtonDown(1))
        {
            win_flag = 1;
            Vector3 spot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dis_error.x = spot.x - transform.position.x;
            dis_error.y = spot.y - transform.position.y;
            float Error = (float)(Math.Pow(dis_error.x,2)+Math.Pow(dis_error.y,2));
            score = (int)(10000 - Error - Error*Fire.fire_counter*10);

            if(Error>Blackhole.m_Radius*Blackhole.m_Radius)
            {
                win_flag = 0;
                text[0].text = "I think you've lost in the universe! Press r to restart.";
            }
            else if(score <= 0)
            {
                win_flag = 0;
                text[0].text = "Score:" + 0 + "  You use too much dectectors.";
            }
            else
            {
                win_flag = 1;
                text[0].text = "Score: " + score + "  Press space to next level.";
            }
            
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        level += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
