using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 1f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    // [SerializeField] Transform gun;

    // float xSpeed;
    // float ySpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        // xSpeed = gun.transform.localScale.x * bulletSpeed;
        // ySpeed = gun.transform.localScale.y * bulletSpeed;
        

    }

    void Update()
    {
        // myRigidbody.velocity = new Vector2 (xSpeed, ySpeed);
        // Vector3 target = Input.mousePosition;
        // myRigidbody.velocity = target * bulletVelocity;
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
