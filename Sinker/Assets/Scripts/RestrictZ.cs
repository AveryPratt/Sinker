using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictZ : MonoBehaviour
{
    private Vector3 TempPos;

    private void Update()
    {
        TempPos = transform.position;
        TempPos.z = 0;
        transform.position = TempPos;
    }
}
