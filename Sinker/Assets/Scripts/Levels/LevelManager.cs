using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{
    public bool Started { get; protected set; }

    public abstract void StartLevel();
}
