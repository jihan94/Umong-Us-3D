using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NuclearReactor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform maxPos;
    [SerializeField] RectTransform minPos;
    [SerializeField] Image activeColor;
    [SerializeField] Text txt;
    [SerializeField] GameObject razor;
    [SerializeField] Canvas reactor;
    RectTransform razorPoint;

    public bool isClear;
    public bool isStabillize = true;
    private int timeCount;
    private bool isTouching = false;
    public bool IsTouching
    {
        get { return isTouching; }
        set { isTouching = value; }
    }

    private bool isMovingUp = false;

    private void Awake()
    {
        isStabillize = true;
        activeColor.color = new Color(255, 0, 0, 200);
        razor.SetActive(false);
        razorPoint = razor.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isClear)
        {
            txt.text = "성공!";
            StopAllCoroutines();
            Invoke("StopReactor", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) reactor.enabled = false;
    }

    IEnumerator RazorMoving(bool whileTouch)
    {
        while (whileTouch)
        {
            if (razorPoint.localPosition.y < minPos.localPosition.y) isMovingUp = true;
            else if (razorPoint.localPosition.y > maxPos.localPosition.y) isMovingUp = false;

            if (isMovingUp) razorPoint.position = new Vector3(razorPoint.position.x, razorPoint.position.y + 3, razorPoint.position.z);
            else if (!isMovingUp) razorPoint.position = new Vector3(razorPoint.position.x, razorPoint.position.y - 3, razorPoint.position.z);

            yield return null;
        }
    }

    IEnumerator CountTime(bool whileTouch)
    {
        while (whileTouch)
        {
            if (timeCount >= 5) isClear = true;
            timeCount++;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouching = true;
        activeColor.color = new Color(0, 255, 0, 200);
        razor.SetActive(true);
        StartCoroutine(CountTime(isTouching));
        StartCoroutine(RazorMoving(isTouching));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        timeCount = 0;
        isTouching = false;
        if (!isClear) activeColor.color = new Color(255, 0, 0, 200);
        razor.SetActive(false);
        StopAllCoroutines();
    }

    private void StopReactor()
    {
        reactor.enabled = false;
        isStabillize = true;
    }

    public void ResetAcro()
    {
        StopAllCoroutines();
        txt.text = "길게 눌러 원자로 융해를 막으세요";
        activeColor.color = new Color(255, 0, 0, 200);
        isClear = false;
        timeCount = 0;
        isTouching = false;
        isMovingUp = false;
        isStabillize = true;
    }

}
