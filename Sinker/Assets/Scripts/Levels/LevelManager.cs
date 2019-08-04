using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{
    public Vector3 StartPos;
    public Checkpoint Checkpoint;

    public bool Started { get; protected set; }

    public abstract void StartLevel();

    public abstract bool CheckComplete();
}
