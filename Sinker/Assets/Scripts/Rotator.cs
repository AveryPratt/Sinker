using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float SpeedMultiplier = 1;

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 90 * SpeedMultiplier);
    }
}
