
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vale : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
              SceneManager.LoadScene("Caverna");
        }


        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
