using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Gold;
    public int startGold = 600;
    
    public static int Lives;
    public int startLives = 10;

    void Start()
    {
        Gold = startGold;
        Lives = startLives;
    }
}
