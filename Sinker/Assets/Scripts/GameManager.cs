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
    private bool LateUpdateTimeScale0;

    private void Start()
    {
        if (DataController.Instance && DataController.Instance.LevelToLoad > 0)
        {
            Level = DataController.Instance.LevelToLoad;
            TrackingCamera.Instance.Targets[1].SetActive(false);
            TrackingCamera.Instance.Pivot.transform.position = new Vector3(Levels[Level].StartPos.x, Levels[Level].StartPos.y, TrackingCamera.Instance.Pivot.transform.position.z);
            TrackingCamera.Instance.Targets[0].transform.position = Levels[Level].StartPos;
            for (int i = 0; i < Level + 1; i++)
            {
                Levels[i].Checkpoint.Previous.gameObject.SetActive(false);
            }
            StartLvl();

            LateUpdateTimeScale0 = true;
            TrackingCamera.Instance.CheckpointHit = true;
            Vector3 CameraPos = Levels[Level].Checkpoint.Previous.LerpCameraX();
            TrackingCamera.Instance.LerpTarget = CameraPos;
            TrackingCamera.Instance.ZoomLerpTarget = Levels[Level].Checkpoint.Previous.CameraSize;
            Level += 1;
        }
    }

    private void LateUpdate()
    {
        if (LateUpdateTimeScale0)
        {
            TimeManager.Instance.TargetTimeScale = 0;
            LateUpdateTimeScale0 = false;
        }
    }

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
        DataController.Instance.LevelToLoad = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Retry()
    {
        DataController.Instance.LevelToLoad = Level - 1;
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
