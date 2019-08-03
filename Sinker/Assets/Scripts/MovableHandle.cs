using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableHandle : MonoBehaviour
{
    public Movable[] Movables;

    public bool Grab()
    {
        bool grabbed = Movables.Length > 0;
        foreach (Movable movable in Movables)
        {
            if (!movable.Grab())
            {
                grabbed = false;
            }
        }
        return grabbed;
    }

    public void Release()
    {
        foreach (Movable movable in Movables)
        {
            movable.Release();
        }
    }
}
