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

    private void Awake()
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
            GameManager.Instance.StartLvl();
            GameManager.Instance.Level += 1;

            TimeManager.Instance.TargetTimeScale = 0;
            TrackingCamera.Instance.CheckpointHit = true;
            LerpCameraX();
            TrackingCamera.Instance.LerpTarget = CameraPos;
            TrackingCamera.Instance.ZoomLerpTarget = CameraSize;
            gameObject.SetActive(false);
        }
    }

    public Vector3 LerpCameraX()
    {
        CameraPos.x = 0;
        foreach (GameObject target in TrackingCamera.Instance.Targets)
        {
            CameraPos.x += target.transform.position.x + target.GetComponent<Rigidbody>().velocity.x;
        }
        CameraPos.x /= TrackingCamera.Instance.Targets.Count;
        return CameraPos;
    }

    public Vector3 LerpCamera()
    {
        Vector3 pos = Vector3.zero;
        foreach (GameObject target in TrackingCamera.Instance.Targets)
        {
            CameraPos += target.transform.position + target.GetComponent<Rigidbody>().velocity;
        }
        CameraPos /= TrackingCamera.Instance.Targets.Count;
        return CameraPos;
    }
}