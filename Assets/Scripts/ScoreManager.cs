using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text KillText;
    public Text enemyTraget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KillText.text = GunController.instance.enemiesKilled.ToString() +"/";
       
        enemyTraget.text = ""+ GunController.instance.num;
    }
}