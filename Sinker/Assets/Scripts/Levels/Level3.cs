using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : LevelManager
{
    public FadeInText Text1;
    public FadeInText Text2;
    public GameObject[] ToEnable;
    public float StartTime;

    private bool Switched;

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

        Text1.Text.text = "Press Space to...";
        Text2.Text.text = "you know the drill, right?";
        Text1.FadeIn();

        StartTime = Time.unscaledTime;
        Started = true;
    }

    public override bool CheckComplete()
    {
        if (!Switched && Time.unscaledTime - StartTime > 1)
        {
            Text1.FadeOut();
            Text2.FadeIn();
            Switched = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Text1.FadeOut();
            Text2.FadeOut();
            return true;
        }
        return false;
    }
}
