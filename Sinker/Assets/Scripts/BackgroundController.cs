using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private static BackgroundController _instance;
    public static BackgroundController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BackgroundController>();
            }
            return _instance;
        }
    }

    public MeshRenderer MeshRenderer;
    public Material SoloBackgroundMaterial;
    public Material MultipleBackgroundMaterial;

    private void Update()
    {
        if (Time.timeSinceLevelLoad > 10.6)
        {
            if (TrackingCamera.Instance.Targets.Count > 1)
            {
                MeshRenderer.material.Lerp(MeshRenderer.material, MultipleBackgroundMaterial, Time.unscaledDeltaTime);
            }
            else
            {
                MeshRenderer.material.Lerp(MeshRenderer.material, SoloBackgroundMaterial, Time.unscaledDeltaTime);
            }
        }
    }
}
