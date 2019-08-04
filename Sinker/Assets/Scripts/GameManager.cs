using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public TrackingCamera Camera;
    public GameObject EndPanel;
    public FadeInText Text1;

    private float RestartTimer;

    private void Update()
    {
        if (Camera.Targets.Count == 0)
        {
            RestartTimer += Time.unscaledDeltaTime;
        }

        if (RestartTimer >= 3)
        {
            EndPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Checkpoint1()
    {
        Text1.gameObject.SetActive(true);
    }
}
