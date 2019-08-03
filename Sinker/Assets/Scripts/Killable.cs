using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    public Material DeadMaterial;
    public Rigidbody Rigidbody;
    public BallLight BallLight;
    public bool MustBeActive;

    private bool Dead;
    private float StuckTime;

    public void Die()
    {
        Dead = true;
        if (BallLight)
        {
            BallLight.Extinguish();
        }
    }

    private void Update()
    {
        if (Dead)
        {
            MeshRenderer.material.Lerp(MeshRenderer.material, DeadMaterial, Time.deltaTime);
        }
        else if (MustBeActive)
        {
            if (Rigidbody.velocity.sqrMagnitude < .01f)
            {
                StuckTime += Time.deltaTime;
            }
            else
            {
                StuckTime = 0;
            }
            if (StuckTime > 1)
            {
                Die();
            }
        }
    }
}
