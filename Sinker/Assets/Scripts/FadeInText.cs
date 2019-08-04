using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text;

    private Color FadeInColor;
    private Color FadeOutColor;
    private bool FadeIn;

    private void Start()
    {
        FadeInColor = Text.color;
        FadeOutColor = FadeInColor;
        FadeOutColor.a = 0;
        Text.color = FadeOutColor;
        FadeIn = true;
    }

    public void FadeOut()
    {
        FadeIn = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeOut();
        }

        if (FadeIn)
        {
            Text.color = Color.Lerp(Text.color, FadeInColor, Time.unscaledDeltaTime);
        }
        else
        {
            Text.color = Color.Lerp(Text.color, FadeOutColor, Time.unscaledDeltaTime);
        }
    }
}
