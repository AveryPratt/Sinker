using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiminishLight : MonoBehaviour
{
    public Light Light;

    private void Update()
    {
        Light.intensity = 20 - 4 * Mathf.Log(46 - Light.transform.position.y);
    }
}
