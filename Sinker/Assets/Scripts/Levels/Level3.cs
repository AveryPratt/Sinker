using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : LevelManager
{
    public FadeInText Text;

    public GameObject[] ToEnable;

    public override void StartLevel()
    {
        foreach (GameObject obj in ToEnable)
        {
            obj.SetActive(true);
        }

        //Text.gameObject.SetActive(true);

        Started = true;
    }
}
