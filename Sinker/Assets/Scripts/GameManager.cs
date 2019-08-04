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
    public ScrollText WarningText;
    public TitleText TitleText;

    private float RestartTimer;
    private bool LateUpdateTimeScale0;
    private bool WarningActivated;
    private bool TitleActivated;
    private bool Skipped;

    private void Start()
    {
        if (DataController.Instance && DataController.Instance.LevelToLoad > 0)
        {
            Skipped = true;
            Level = DataController.Instance.LevelToLoad;
            TrackingCamera.Instance.Targets[1].SetActive(false);
            TrackingCamera.Instance.Pivot.transform.position = new Vector3(Levels[Level].StartPos.x, Levels[Level].StartPos.y, TrackingCamera.Instance.Pivot.transform.position.z);
            TrackingCamera.Instance.Targets[0].transform.position = Levels[Level].StartPos;
            Vector3 CameraPos = Levels[Level].Checkpoint.Previous.LerpCameraX();
            StartLvl();

            LateUpdateTimeScale0 = true;
            TrackingCamera.Instance.CheckpointHit = true;
            TrackingCamera.Instance.LerpTarget = CameraPos;
            TrackingCamera.Instance.ZoomLerpTarget = Levels[Level].Checkpoint.Previous.CameraSize;
            for (int i = 0; i < Level + 1; i++)
            {
                Levels[i].Checkpoint.Previous.gameObject.SetActive(false);
            }
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

        if (Time.timeSinceLevelLoad > 8 && !WarningActivated && !Skipped)
        {
            WarningText.gameObject.SetActive(true);
            WarningActivated = true;
        }

        if (Time.timeSinceLevelLoad > 14.2 && !TitleActivated && !Skipped)
        {
            TitleText.gameObject.SetActive(true);
            TitleActivated = true;
        }

        if (Level > 0 && Level <= Levels.Length)
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
        Application.Quit();
    }

    public void StartLvl()
    {
        if (Levels.Length > Level && !Levels[Level].Started)
        {
            Levels[Level].StartLevel();
        }
    }
}
