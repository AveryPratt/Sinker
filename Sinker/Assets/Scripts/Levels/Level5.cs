using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : LevelManager
{
    public GameObject[] ToEnable;

    public override void StartLevel()
    {
        transform.position = new Vector3(TrackingCamera.Instance.Targets[0].transform.position.x, transform.position.y, transform.position.z);

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
