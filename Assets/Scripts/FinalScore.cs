using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class FinalScore : MonoBehaviour
{
    public Text scoreText;
     public Text enemieskilled;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerMovement.instance.score.ToString();
        enemieskilled.text = "Enemieskilled:" + Health.instance.enemiesKilled.ToString()+"/4";

    }
}