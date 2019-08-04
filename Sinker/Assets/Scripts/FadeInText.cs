using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text;

    private Color FadeInColor;
    private Color FadeOutColor;
    private bool FadingIn;

    private void Start()
    {
        FadeInColor = Text.color;
        FadeOutColor = FadeInColor;
        FadeOutColor.a = 0;
        Text.color = FadeOutColor;
        FadingIn = false;
    }

    public void FadeOut()
    {
        FadingIn = false;
    }

    public void FadeIn()
    {
        FadingIn = true;
    }

    private void Update()
    {
        if (FadingIn)
        {
            Text.color = Color.Lerp(Text.color, FadeInColor, Time.unscaledDeltaTime);
        }
        else
        {
            Text.color = Color.Lerp(Text.color, FadeOutColor, Time.unscaledDeltaTime);
        }
    }
}
