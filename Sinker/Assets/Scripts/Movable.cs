using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    public Material ReleasedMaterial;

    public GameObject GrabBox;

    private bool Grabbed;
    private bool Released;

    private void Start()
    {
        float grabBoxScaleX = MeshRenderer.transform.localScale.x + 1 / MeshRenderer.transform.localScale.x;
        float grabBoxScaleY = MeshRenderer.transform.localScale.y + 1 / MeshRenderer.transform.localScale.y;
        transform.localScale = new Vector3(grabBoxScaleX, grabBoxScaleY, 2);
    }

    public void Release()
    {
        Released = true;
    }

    public bool Grab()
    {
        if (!Released)
        {
            Grabbed = true;
        }
        return Grabbed;
    }

    private void Update()
    {
        if (Grabbed)
        {
            MeshRenderer.transform.position = InputController.Instance.MouseWorldPosition;
        }
        if (Released)
        {
            Grabbed = false;
            MeshRenderer.material.Lerp(MeshRenderer.material, ReleasedMaterial, Time.deltaTime);
        }
    }
}
