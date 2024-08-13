using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("Vale");
    }
    public void Configu()
    {
        SceneManager.LoadScene("configu");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
