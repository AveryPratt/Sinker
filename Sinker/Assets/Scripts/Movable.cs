using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    public Material ReleasedMaterial;

    public BoxCollider CollisionBox;
    public GameObject GrabBox;
    public MovableHandle Handle;

    public bool Grabbed { get; private set; }
    public bool Released { get; private set; }

    private Vector3 baseScale;

    private void Start()
    {
        float grabBoxScaleX = MeshRenderer.transform.localScale.x + 1 / MeshRenderer.transform.localScale.x;
        float grabBoxScaleY = MeshRenderer.transform.localScale.y + 1 / MeshRenderer.transform.localScale.y;
        transform.localScale = new Vector3(grabBoxScaleX, grabBoxScaleY, 2);
        baseScale = MeshRenderer.transform.localScale;
    }

    public void Release()
    {
        Released = true;
        CollisionBox.enabled = true;
    }

    public bool Grab()
    {
        if (!Released)
        {
            Grabbed = true;
            CollisionBox.enabled = false;
        }
        return Grabbed;
    }

    private void Update()
    {
        if (Grabbed)
        {
            Handle.transform.position = InputController.Instance.MouseWorldPosition;
        }
        if (Released)
        {
            Grabbed = false;
            MeshRenderer.material.Lerp(MeshRenderer.material, ReleasedMaterial, Time.unscaledDeltaTime);
        }
        if (!Grabbed && !Released)
        {
            MeshRenderer.transform.localScale = baseScale * (1.25f + (1 - Time.timeScale) * Mathf.Sin(Time.unscaledTime * 6) * .25f - .25f * Time.timeScale);
        }
        else
        {
            MeshRenderer.transform.localScale = baseScale;
        }
    }
}
