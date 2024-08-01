using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameDefined(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
    }

        public void DisPauseButton()
    {
        Time.timeScale = 1f;
    }

}
