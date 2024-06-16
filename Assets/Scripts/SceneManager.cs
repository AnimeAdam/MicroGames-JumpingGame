using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void GoToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
