using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float timerTotal = 1f;
    public GameObject prefab;
    float timerCurrent = .5f;

    void Start() 
    {
        prefab = Resources.Load("Bullet") as GameObject;
    }

    void Update() 
    {
        timerCurrent += Time.deltaTime;
        if(timerCurrent >= timerTotal)
        {
            GameObject Bullet = Instantiate(prefab) as GameObject;
            Bullet.transform.position = transform.position + Camera.main.transform.forward *2;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Camera.main.transform.forward *20;
            timerCurrent -= timerTotal;
        }
    }
}
