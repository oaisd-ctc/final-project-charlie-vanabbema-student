using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    // public GameObject hook;
    // public Transform start;
    public float firespeed = 10f;


    // private Camera mainCam;
    // private Vector3 mousePos;
    void Start()
    {


        // mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 armpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(armpos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }
        // if(Input.GetMouseButtonDown(0))
        // {
        //     Hooking();
        // }

    // void Hooking()
        // {
            // GameObject grapple = Instantiate(hook, start.transform.position, start.transform.rotation);
            // hook.start.transform;
            // Destroy(hook, 0.5f);
            // transform.Translate(Vector2.right * firespeed * Time.deltaTime, Space.Self);

        // }

        // mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
 
        // Vector3 rotation = mousePos - transform.position;

        // float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        // transform.rotation = Quaternion.Euler(0, 0, rotz);
    }

    
}
