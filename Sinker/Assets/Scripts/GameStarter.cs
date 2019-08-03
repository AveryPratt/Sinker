using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public Camera Camera;

    private void Update()
    {
        Camera.backgroundColor = Color.Lerp(Camera.backgroundColor, Color.black, Time.deltaTime / 5);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
