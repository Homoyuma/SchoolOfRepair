using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
