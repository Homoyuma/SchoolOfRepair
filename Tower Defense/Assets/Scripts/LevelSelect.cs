using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Level1Button ()
    {
        SceneManager.LoadScene ("Level 1");
    }
    public void Level2Button ()
    {
        SceneManager.LoadScene("Level 2");
    }
}
