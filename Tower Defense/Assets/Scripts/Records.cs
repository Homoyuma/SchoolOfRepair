using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Records : MonoBehaviour
{    
    public Text score;

    void Update () {
        score.text = "Score: " + MoveToWayPoint.score;
    }
}