using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    private static TrackingCamera _instance;
    public static TrackingCamera Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TrackingCamera>();
            }
            return _instance;
        }
    }

    public Camera Camera;
    public Transform Pivot;
    public List<GameObject> Targets;
    public bool CheckpointHit;
    public Vector3 LerpTarget;
    public float ZoomLerpTarget;

    private void Start()
    {
        LerpTarget = Pivot.transform.position;
        ZoomLerpTarget = 5;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(InputController.Instance.MouseWorldPosition * .01f);
    }

    private void FixedUpdate()
    {
        SetLerpTarget();
        Pivot.transform.position = Vector3.Lerp(Pivot.transform.position, LerpTarget, Time.unscaledDeltaTime);
        Camera.orthographicSize = Mathf.Lerp(Camera.orthographicSize, ZoomLerpTarget, Time.unscaledDeltaTime);
    }

    private void SetLerpTarget()
    {
        if (!CheckpointHit)
        {
            if (Targets.Count > 0)
            {
                LerpTarget = Vector3.zero;
                foreach (GameObject target in Targets)
                {
                    LerpTarget += target.transform.position + target.GetComponent<Rigidbody>().velocity;
                }
                LerpTarget /= Targets.Count;
                LerpTarget.z = Pivot.transform.position.z;
            }
        }
    }
}
