using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartWithTitle : MonoBehaviour
{
    private void Start()
    {
        if (MusicController.Instance == null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
