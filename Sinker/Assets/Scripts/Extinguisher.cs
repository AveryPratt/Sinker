using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    public MeshRenderer[] MeshRenderers;
    public Material DeadMaterial;

    private bool Extinguished;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("ball"))
        {
            BallLight light = collision.transform.GetComponent<BallLight>();
            BallKiller killer = collision.transform.GetComponent<BallKiller>();
            if (light)
            {
                light.Extinguish();
            }
            if (killer)
            {
                killer.Die();
            }
            Extinguished = true;
        }
    }

    private void Update()
    {
        if (Extinguished)
        {
            foreach (MeshRenderer renderer in MeshRenderers)
            {
                renderer.material.Lerp(renderer.material, DeadMaterial, Time.deltaTime);
            }
        }
    }
}
