using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollText : MonoBehaviour
{
    public RectTransform RectTransform;
    public TMPro.TextMeshProUGUI Text;

    private Vector3 RectPos;
    private float Timer;
    private Color TextColor;

    private void OnEnable()
    {
        RectPos.y = 400;
        Timer = 0;
    }

    private void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        RectPos = new Vector3(1000, 400, 0);
        TextColor = Text.color;
    }

    private void Update()
    {
        RectPos.y += Time.deltaTime * 100;
        RectTransform.position = RectPos;
        Timer += Time.deltaTime;
        float alpha = (200 - Mathf.Abs(RectPos.y - 600)) / 200;
        TextColor.a = alpha;
        Text.color = TextColor;
        if (Timer > 4)
        {
            gameObject.SetActive(false);
        }
    }
}
