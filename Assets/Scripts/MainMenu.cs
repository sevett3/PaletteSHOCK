using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayTutorial() {
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayLv1() {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLv2() {
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
