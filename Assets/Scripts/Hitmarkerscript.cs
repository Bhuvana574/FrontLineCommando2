using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitmarkerscript : MonoBehaviour
{
    public static Hitmarkerscript hitPoolInstance;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PushtoPool", 1f);
    }
    private void Update()
    {
        Invoke("PushtoPool", 1f);
    }
    // Update is called once per frame
    public void PushtoPool()
    {
        HitMarkerManager.hitinstance.AddHitMarkerPool(this.gameObject);
        //Destroy(this.gameObject);
    }
}