using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Boom");
    }

    public void Options()
    {

    }

    public void QuitGame()
    {
        //Debug to check quit works, since Unity Play will not allow us to test this feature
        Debug.Log("Quit");
        Application.Quit();
    }
}