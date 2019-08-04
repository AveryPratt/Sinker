using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : LevelManager
{
    public GameObject[] ToEnable;

    public override void StartLevel()
    {
        if (TrackingCamera.Instance.Targets.Count > 0)
        {
            transform.position = new Vector3(TrackingCamera.Instance.Targets[0].transform.position.x, transform.position.y, transform.position.z);
        }

        foreach (GameObject obj in ToEnable)
        {
            obj.SetActive(true);
        }
        
        Started = true;
    }

    public override bool CheckComplete()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }
}
