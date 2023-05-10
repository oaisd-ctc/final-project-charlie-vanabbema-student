using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject crossHair;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crossHair.gameObject.SetActive(true);
 
             var mousePos = Input.mousePosition;
             mousePos.z = 10;
             crossHair.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
