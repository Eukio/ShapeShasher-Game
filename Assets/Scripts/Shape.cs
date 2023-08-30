using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Shape : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] double time;
    bool clicked;
    long startTime;
    long elapsed;
    bool loseLife;
    bool stopTime;

    // Start is called before the first frame update
    void Start()
    {
     clicked = false;
        loseLife = false;
        stopTime = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (!stopTime) { 
        elapsed = (DateTime.Now.Ticks - startTime) / 10000;
        if (elapsed >= time)
        {
            Debug.Log("Move");
            RandPos();
            loseLife = true;
            RestartTime();
        }
    }
        //Timer
        //Destroy Shape, create random shape location

    }

    public void OnMouseDown()
    {
        if (!stopTime) { 
        RestartTime();
        Debug.Log("I am worth " + points + " points. time:" + elapsed + " check: " + startTime);
        clicked = true;
        RandPos();
    }
     
    }
    

    public bool Clicked()
    {
        return clicked; 
    }
    public void SetClicked(bool clicked)
    {
        this.clicked = clicked;
    }
    public int GetPoints()
    {
        return points;
    }
    public bool LoseLife()
    {
        return loseLife;
    }
    public void SetLife(bool loseLife)
    {
        this.loseLife = loseLife;
    }
    public void RandPos()
    {
        float posX = Random.Range(-4.1f, 4.2f);
        float posY = Random.Range(-4.1f, 3f);
        GetComponent<Transform>().position = new Vector3(posX, posY, 0);
    }
    public void RestartTime()
    {
        startTime = DateTime.Now.Ticks;
        elapsed = 0;
    }
    public void StopTime(bool stop)
    {
        this.stopTime = stop;
       
    }
}
