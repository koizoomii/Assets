using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour
{
    public Text pointsText;
    public Text tupoints_text;
    public Text gopoints_text;

    public int timeup_points;
    public int gameover_points;
    public int currentPoints;
    AudioSource pointsfx;


    void Start()
    {
        currentPoints = 0;

        timeup_points = currentPoints;
        gameover_points = currentPoints;

        pointsfx = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        pointsText.text = currentPoints.ToString();
        tupoints_text.text = currentPoints.ToString();
        gopoints_text.text = currentPoints.ToString();
    }

    public void ResetPoints()
    {
        currentPoints = 0;
    }

    public void earnPoints(int amount)
    {
        currentPoints += amount;
        GetComponent<AudioSource>().Play();
    }
}
