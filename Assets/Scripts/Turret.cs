using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // public float timerTotal = 1f;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;


    [SerializeField] int delay = 2;

    [SerializeField] AudioClip turretSFX;
    // Rigidbody2D myRigidbody;
    // public GameObject prefab;
    

    void Start() 
    {
        // myRigidbody = GetComponent<Rigidbody2D>();
        // prefab = Resources.Load("Bullet") as GameObject;
    }

    void Update() 
    {
        if(delay % 50 == 0)
        {
            Instantiate(bullet, gun.position, gun.transform.rotation);
            AudioSource.PlayClipAtPoint(turretSFX, gun.transform.position);
        }
        delay++;
        
        
        // timerCurrent += Time.deltaTime;
        // // if(timerCurrent >= timerTotal)
        // // {
        //     GameObject Bullet = Instantiate(prefab) as GameObject;
        //     Bullet.transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime, Space.Self);
        //     // Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //     // rb.velocity = Camera.main.transform.forward *20;
        //     // timerCurrent -= timerTotal;
        // // }
    }
}
