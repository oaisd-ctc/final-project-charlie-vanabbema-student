using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 armPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - armPos.x;
        mousePos.y = mousePos.y - armPos.y;
        float armAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -armAngle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, armAngle));
        }

    }
}
