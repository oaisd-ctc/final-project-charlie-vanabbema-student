using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 25f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime, Space.Self);
    }

    //     void OnTriggerEnter2D(Collider2D other)
    // {
    //     // if(other.tag == "Player")
    //     // {
    //         Destroy(gameObject);
    //     // }
    // }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

}
