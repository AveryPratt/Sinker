using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : LevelManager
{
    public FadeInText Text1;
    public FadeInText Text2;
    public GameObject[] ToEnable;
    public Movable ObjectToDrop;

    private bool HitSpace;

    public override void StartLevel()
    {
        foreach (GameObject obj in ToEnable)
        {
            obj.SetActive(true);
        }

        Text1.FadeIn();

        Started = true;
    }
    
    public override bool CheckComplete()
    {
        if (ObjectToDrop.Released)
        {
            Text1.FadeOut();
            Text2.FadeIn();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Text2.FadeOut();
                return true;
            }
        }
        return false;
    }
}
