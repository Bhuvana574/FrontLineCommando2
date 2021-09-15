using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class FinalScore : MonoBehaviour
{
    public Text scoreText;
    public Text enemieskilled;
    public Text enemyTarget;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + GunController.instance.score.ToString();
        enemieskilled.text = "KillScore:" + GunController.instance.enemiesKilled.ToString();
        enemyTarget.text = " /" + GunController.instance.num;
       

    }
}