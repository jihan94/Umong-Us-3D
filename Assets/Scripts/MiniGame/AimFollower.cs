using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimFollower : MonoBehaviour
{
    public float velocity = 0.0f;
    public RectTransform bgSize;

    private RectTransform rTr;

    Vector2 mousePos;



    public void Start()
    {
        rTr = GetComponent<RectTransform>();
        bgSize.GetComponent<RectTransform>();
    }

    public void Update()
    {
        mousePos = Input.mousePosition;

        if (RectTransformUtility.RectangleContainsScreenPoint(bgSize, mousePos))
        {
            if (Input.GetMouseButtonDown(0))
                transform.position = mousePos;
        }

    }


}
