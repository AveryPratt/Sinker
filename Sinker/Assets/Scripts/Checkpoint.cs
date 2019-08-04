using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Checkpoint : MonoBehaviour
{
    public EventTrigger.TriggerEvent Event;
    public BoxCollider BoxCollider;
    public Extinguisher Extinguisher;
    public float YPos = -6;
    public float CameraSize = 5;

    private Vector3 CameraPos;

    private void Start()
    {
        CameraPos = transform.position + new Vector3(0, YPos, TrackingCamera.Instance.transform.position.z);
    }

    private void Update()
    {
        BoxCollider.isTrigger = !Extinguisher.Extinguished && TrackingCamera.Instance.Targets.Count <= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            TimeManager.Instance.TargetTimeScale = 0;
            TrackingCamera.Instance.CheckpointHit = true;
            CameraPos.x = TrackingCamera.Instance.LerpTarget.x;
            TrackingCamera.Instance.LerpTarget = CameraPos;
            TrackingCamera.Instance.ZoomLerpTarget = CameraSize;

            Event.Invoke(new BaseEventData(EventSystem.current));
        }
    }
}