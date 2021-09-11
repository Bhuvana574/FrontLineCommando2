using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
