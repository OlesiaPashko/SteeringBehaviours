using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour, IDesiredVelocityProvider
{
    //[SerializeField]
   // private Transform objectToFollow;
    public Vector3 GetDesiredVelocity()
    {
        //return (objectToFollow.position - transform.position).normalized * Wolf.VelocityLimit;
        return (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * Wolf.VelocityLimit;
    }
}
