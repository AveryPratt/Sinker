using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKiller : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    public Material DeadMaterial;

    private bool Dead;

    public void Die()
    {
        Dead = true;
    }

    private void Update()
    {
        if (Dead)
        {
            MeshRenderer.material.Lerp(MeshRenderer.material, DeadMaterial, Time.deltaTime);
        }
    }
}
