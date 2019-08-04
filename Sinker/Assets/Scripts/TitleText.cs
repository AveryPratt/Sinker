using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text;
    private float StartTime;
    private Color TextColor;

    private void OnEnable()
    {
        StartTime = Time.time + 4;
        TextColor = Text.color;
    }

    private void Update()
    {
        if (Time.time > StartTime)
        {
            float alpha = 1 - (Time.time - StartTime) / 2;
            TextColor.a = alpha;
            Text.color = TextColor;
            if (alpha <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
