using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadWinScene()
    {
        SceneManager.LoadScene("Win");
    }
}
