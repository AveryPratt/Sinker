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

    public List<GameObject> Targets;
    public bool CheckpointHit;
    public Vector3 LerpTarget;

    private void Start()
    {
        LerpTarget = transform.position;
    }

    private void FixedUpdate()
    {
        SetLerpTarget();
        transform.position = Vector3.Lerp(transform.position, LerpTarget, Time.unscaledDeltaTime * 10);
    }

    private void SetLerpTarget()
    {
        if (!CheckpointHit)
        {
            LerpTarget = Vector3.zero;
            if (Targets.Count > 0)
            {
                foreach (GameObject target in Targets)
                {
                    LerpTarget += target.transform.position;
                }
                LerpTarget /= Targets.Count;
            }
            LerpTarget.z = transform.position.z;
        }
    }
}
