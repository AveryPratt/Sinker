using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableHandle : MonoBehaviour
{
    public Movable[] Movables;

    private bool Grabbed;
    private bool Released;
    private Vector3 baseScale;

    public bool Grab()
    {
        Grabbed = Movables.Length > 0;
        foreach (Movable movable in Movables)
        {
            if (!movable.Grab())
            {
                Grabbed = false;
            }
        }
        return Grabbed;
    }

    public void Release()
    {
        foreach (Movable movable in Movables)
        {
            movable.Release();
        }
        Released = true;
    }

    private void Start()
    {
        baseScale = transform.localScale;
    }

    private void Update()
    {
        if (!Grabbed && !Released)
        {
            transform.localScale = baseScale * (1.25f + (1 - Time.timeScale) * Mathf.Sin(Time.unscaledTime * 6) * .25f - .25f * Time.timeScale);
        }
        else
        {
            transform.localScale = baseScale;
        }
    }
}
