using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOnFootControl : MonoBehaviour
{
    public int RedCount;
    public float gameTime = 0;
    private int sign = 1;
    public bool startFromZero = false;
    public float startTime = 121;
    public Text cron;

    public void Start()
    {
        if (!startFromZero)
        {
            sign = -1;
            gameTime = startTime;
        }
    }


    public void Update()
    {
        gameTime = gameTime + sign * Time.deltaTime;

        if (!startFromZero && gameTime <= 0)
        {
            Application.LoadLevel(0);
            // ou Application.LoadLevel("NomeDaCena");
        }

        int minutes = (int)(gameTime / 60);
        int seconds = (int)(gameTime % 60);
        cron.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.tag == "amarelo" && Input.GetKeyDown(KeyCode.E))
        { 
            Destroy(hit.gameObject);
            gameTime += 20;
        }
        if (hit.gameObject.tag == "vermelho" && Input.GetKeyDown(KeyCode.E))
        {
            RedCount++;
            //Debug.Log(RedCount);
            if (RedCount >= 2)
            {
                Destroy(hit.gameObject);
                RedCount = 0;
                gameTime += 20;
            }
        }
    }
}