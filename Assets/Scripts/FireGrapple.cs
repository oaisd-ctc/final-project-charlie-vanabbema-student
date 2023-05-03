using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGrapple : MonoBehaviour
{
    public float firespeed = 10f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            transform.Translate(Vector2.right * firespeed * Time.deltaTime, Space.Self);
        }
    }

//     void fireGrapple(InputValue value)
//     {
//         transform.Translate(Vector2.right * firespeed * Time.deltaTime, Space.Self);
//     }

//     // void OnCollisionEnter2D(Collision2D other) 
//     //     {
//     //         Destroy(gameObject, 0.5f);
//     //     }
}
