using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestRecord : MonoBehaviour
{
    public Text highscore;
    public int highestrecord;

    void Start()
    {
        highestrecord = PlayerPrefs.GetInt("savescores");
        highscore.text = "Record is " + highestrecord.ToString() + ". Great job!";
    }
}