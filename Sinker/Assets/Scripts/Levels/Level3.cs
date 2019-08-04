using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : LevelManager
{
    public GameObject[] ToEnable;

    public override void StartLevel()
    {
        foreach (GameObject obj in ToEnable)
        {
            obj.SetActive(true);
        }

        Started = true;
    }

    public override bool CheckComplete()
    {
        return false;
    }
}
