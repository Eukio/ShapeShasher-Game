using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    int deaths;
    [SerializeField] Shape circle;
    [SerializeField] Shape square;
    [SerializeField] Shape triangle;
    [SerializeField] Text score;
    [SerializeField] GameObject live1;
    [SerializeField] GameObject live2;
    [SerializeField] GameObject live3;


    bool run;
     int total;
    void Start()
    {
        deaths = 0;
        total = 0;
        Restart(out deaths);

    }

    // Update is called once per frame
    void Update()
    {
        if (run) { 
        if (circle.Clicked())
        {
            total += circle.GetPoints();
            circle.SetClicked(false);
        }
        else if (square.Clicked())
        {
            total += square.GetPoints();
            square.SetClicked(false);

        }
        else if (triangle.Clicked())
        {
            total += triangle.GetPoints();
            triangle.SetClicked(false);

        }
        score.text = total.ToString();

            if (circle.LoseLife() || square.LoseLife() || triangle.LoseLife()) {
               deaths++;
                circle.SetLife(false);
                triangle.SetLife(false);
                square.SetLife(false);
            }
            if (deaths >= 3)
            {
                live3.SetActive(true);
                circle.StopTime(true); //change this
                triangle.StopTime(true);
                square.StopTime(true);
            }
            if (deaths == 2)
            {
                live2.SetActive(true);
            }
            if (deaths == 1)
            {
                live1.SetActive(true);
            }
        }
        
        
         if (Input.GetKeyUp(KeyCode.R) && !run)
                Restart(out deaths);
         //Reddead 2, fallout, firewatch, sumphonie hotline miami
        if (deaths < 3)
            run = true;
        else
            run = false;
    }

    public void SetPoints(int points)
    {
        total += points;
    }
    public void Restart(out int deaths)
    {
        deaths = 0;
        circle.RandPos();
        triangle.RandPos();
        square.RandPos();
        circle.RestartTime();
        triangle.RestartTime();
        square.RestartTime();
        total = 0;
        score.text = total.ToString();
        live1.SetActive(false);
        live2.SetActive(false);
        live3.SetActive(false);
        run = true;

        circle.StopTime(false); //change this
        square.StopTime(false); //change this
        triangle.StopTime(false); //change this


    }
}
