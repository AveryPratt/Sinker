using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider BoxCollider;
    public Extinguisher Extinguisher;
    public float YPos = -6;
    public float CameraSize = 5;
    public Material PassMaterial;
    public Checkpoint Previous;

    private Vector3 CameraPos;

    private void Start()
    {
        CameraPos = transform.position + new Vector3(0, YPos, TrackingCamera.Instance.transform.position.z);
    }

    private void Update()
    {
        if (!Previous || !Previous.gameObject.activeInHierarchy)
        {
            BoxCollider.isTrigger = !Extinguisher.Extinguished && TrackingCamera.Instance.Targets.Count <= 1;

            if (BoxCollider.isTrigger && !Extinguisher.Extinguished)
            {
                foreach (MeshRenderer renderer in Extinguisher.MeshRenderers)
                {
                    renderer.material = PassMaterial;
                }
            }
        }
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
            GameManager.Instance.StartLvl();
            GameManager.Instance.Level += 1;
            gameObject.SetActive(false);
        }
    }
}