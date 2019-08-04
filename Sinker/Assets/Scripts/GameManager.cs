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
    public int Level;
    public LevelManager[] Levels;

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

        if (Level > 0)
        {
            if (Levels[Level - 1].CheckComplete())
            {
                TimeManager.Instance.TargetTimeScale = 1;
                TrackingCamera.Instance.CheckpointHit = false;
            }
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

    public void StartLvl()
    {
        if (!Levels[Level].Started)
        {
            Levels[Level].StartLevel();
        }
    }
}
