﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : LevelManager
{
    public FadeInText Text;
    public GameObject[] ToEnable;

    public override void StartLevel()
    {
        foreach (GameObject obj in ToEnable)
        {
            obj.SetActive(true);
        }

        Text.FadeIn();

        Started = true;
    }

    public override bool CheckComplete()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Text.FadeOut();
            return true;
        }
        return false;
    }
}
