using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    public MeshRenderer[] MeshRenderers;
    public Material DeadMaterial;

    public bool Extinguished { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("ball"))
        {
            Killable killer = collision.transform.GetComponent<Killable>();
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
