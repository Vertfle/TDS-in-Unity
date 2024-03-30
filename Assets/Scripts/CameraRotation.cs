﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float maxAngle;
    public float minAngle;
    public Transform CameraAxisTransform;
    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);
        
        var newAngleX = CameraAxisTransform.localEulerAngles.x + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y") * -1;
        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);    
    }
}