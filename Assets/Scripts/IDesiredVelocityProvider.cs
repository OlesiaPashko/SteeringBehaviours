using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDesiredVelocityProvider
{
    Vector3 GetDesiredVelocity();
}
