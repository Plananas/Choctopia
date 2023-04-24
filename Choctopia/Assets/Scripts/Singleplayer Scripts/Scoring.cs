using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;


    void Update()
    {
        
        scoreText.GetComponent<Text>().text = "Score: " + theScore;

    }
}
