using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableHandle : MonoBehaviour
{
    public Movable[] Movables;

    public void Release()
    {
        foreach (Movable movable in Movables)
        {
            movable.Release();
        }
    }
}
