using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController _instance;
    public static MusicController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MusicController>();
            }
            return _instance;
        }
    }

    public AudioSource MultipleBallsAudio;
    public AudioSource UnderWaterAudio;

    private float MultipleBallsTargetVolume;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (TrackingCamera.Instance != null)
        {
            if (!MultipleBallsAudio.isPlaying && Time.timeSinceLevelLoad > 10.8)
            {
                MultipleBallsAudio.Play();
                MultipleBallsTargetVolume = 1;
                MultipleBallsAudio.volume = 1;
            }
            MultipleBallsTargetVolume = TrackingCamera.Instance.Targets.Count > 1 && Time.timeScale >= 1 ? 1 : 0;
            MultipleBallsAudio.volume = Mathf.Lerp(MultipleBallsAudio.volume, MultipleBallsTargetVolume, Time.unscaledDeltaTime);
        }
        UnderWaterAudio.volume = Mathf.Lerp(UnderWaterAudio.volume, 1, Time.unscaledDeltaTime);
    }
}
