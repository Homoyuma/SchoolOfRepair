using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Level1Button ()
    {
        SceneManager.LoadScene ("SampleScene");
    }
    public void Level2Button ()
    {
        Debug.Log ("There is no level 2!");
    }
}
