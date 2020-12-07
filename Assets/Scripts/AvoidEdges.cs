using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidEdges : DesiredVelocityProvider
{
    private float edge = 0.05f;
    public override Vector3 GetDesiredVelocity()
    {
        var cam = Camera.main;
        var maxSpeed = Animal.VelocityLimit;
        var v = Animal.Velocity;
        if(cam == null)
        {
            //Debug.Log("0");
            return v;
        }
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < edge) 
        { 
            //Debug.Log("I am left of the camera's view.");
            return new Vector3(maxSpeed, 0, 0);
        }
        if (1.0 - edge < pos.x)
        {
            //Debug.Log("I am right of the camera's view.");
            return new Vector3(-maxSpeed, 0, 0);
        }
        if (pos.y < edge)
        {
            //Debug.Log("I am below the camera's view.");
            return new Vector3(0, maxSpeed, 0);
        }
        if (1.0 - edge < pos.y)
        {
            //Debug.Log("I am above the camera's view.");
            return new Vector3(0, -maxSpeed, 0);
        }
        return v;
    }
}
