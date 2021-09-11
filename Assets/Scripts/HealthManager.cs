using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static  HealthManager instance;
    public Slider HealthSlider;
    int heart = 0;
    public void Awake()
    {
        instance = this;
    }

   

}
