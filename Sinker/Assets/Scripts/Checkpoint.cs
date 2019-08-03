using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 CameraPos;

    private void Start()
    {
        CameraPos = transform.position + new Vector3(0, -6, TrackingCamera.Instance.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            TimeManager.Instance.TargetTimeScale = 0;
            TrackingCamera.Instance.CheckpointHit = true;
            CameraPos.x = TrackingCamera.Instance.LerpTarget.x;
            TrackingCamera.Instance.LerpTarget = CameraPos;
        }
    }
}