using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BallLight light = collision.transform.GetComponent<BallLight>();
        if (light)
        {
            light.Extinguish();
        }
    }
}
