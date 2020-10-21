using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CMDiaPos : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    public Transform mSetDiaPos;
    public bool isSetPos;
    public bool isDrag;
    public CombineMiniGame CMG;

    private void Update()
    {
        SetPosObj();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (this.gameObject.tag == other.gameObject.tag && !isDrag)
        {
            if (!isSetPos) CMG.PointsUp();
            isSetPos = true;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = true;
    }
    private void SetPosObj()
    {
        if (isSetPos) this.transform.position = mSetDiaPos.transform.position;
    }
}
