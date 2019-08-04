using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    private static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DataController>();
            }
            return _instance;
        }
    }

    public int LevelToLoad;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
