using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelParentRotation : MonoBehaviour
{
    private Quaternion rotation { get; set; }

    private void Awake()
    {
        rotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
