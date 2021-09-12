using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2StartScript : MonoBehaviour
{
    public void startlevel()
    {
        SceneManager.LoadScene(5);
    }
    public void quitlevel()
    {
        SceneManager.LoadScene(0);
    }

}
