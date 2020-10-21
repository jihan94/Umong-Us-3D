using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleManger : MonoBehaviour
{
    [SerializeField] CircleRotate[] circles = new CircleRotate[3];
    [SerializeField] CircleButton[] circleButtons = new CircleButton[3];
    [SerializeField] GaugeControl[] gauge = new GaugeControl[3];
    [SerializeField] GameObject canvas = null;
    private bool isReset = false;
    void Start()
    {
        StartCoroutine(circles[0].StartRotate());
    }

    private void Update()
    {
        if (circleButtons[0].isPush && circles[0].IsCharged && !circles[0].IsClear)
        {
            circles[0].IsClear = true;
            StartCoroutine(circles[1].StartRotate());
        }
        if (circleButtons[1].isPush && circles[1].IsCharged && !circles[1].IsClear)
        {
            circles[1].IsClear = true;
            StartCoroutine(circles[2].StartRotate());
        }
        if (circleButtons[2].isPush && circles[2].IsCharged && !circles[2].IsClear)
        {
            circles[2].IsClear = true;
            canvas.SetActive(false);
        }

        for(int i = 0; i < 3; ++i)
        {
            if (circleButtons[i].isPush && !circles[i].IsCharged) isReset = true;
            if (circles[i].isCharged) gauge[i].IsLow = false;
            else gauge[i].IsLow = true;
        }

        if (isReset)
        {
            for (int i = 0; i < circles.Length; ++i)
            {
                circles[i].IsClear = false;
                circleButtons[i].isPush = false;
                StartCoroutine(circles[i].ResetRot());
            }
            StopAllCoroutines();
            StartCoroutine(circles[0].StartRotate());
            isReset = false;
        }

    }

}
