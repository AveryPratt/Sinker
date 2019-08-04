using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : LevelManager
{
    public FadeInText Text1;
    public FadeInText Text2;
    public GameObject[] ToEnable;
    public Movable ObjectToDrop;
    
    private bool SpacePressed;

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
            if (!SpacePressed)
            {
                Text1.FadeOut();
                Text2.FadeIn();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Text2.FadeOut();
                    SpacePressed = true;
                    return true;
                }
            }
        }
        return false;
    }
}
