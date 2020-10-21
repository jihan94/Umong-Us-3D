using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeafCrtl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Sprite[] leafImgType = null;

    private Image icon;
    private Transform tr;
    private Vector3 mouseV;
    private Vector3 leafV;
    private Vector3 startPos;
    private int imgIndex;
    private bool isCrash;
    private float angle;
    private float speed;

    public void OnBeginDrag(PointerEventData eventData)
    {
        tr.position = Input.mousePosition;
        speed = 1.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
       if (!isCrash)tr.position = Vector3.Lerp(Input.mousePosition, tr.position, 0.8f);
        tr.transform.Rotate(Vector3.forward, 60 * Time.deltaTime);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        StartCoroutine(Move(Input.mousePosition));  
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "AirCanInlet")
        {
            if (tr.transform.localPosition.y > 20)
            {
                tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y - 5, tr.transform.position.z);
            }
            else if (tr.transform.localPosition.y < -20)
            {
                tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y + 5, tr.transform.position.z);
            }
            if(tr.transform.localPosition.y < 20 && tr.transform.localPosition.y > - 20)
                tr.transform.position = new Vector3(tr.transform.position.x - 10, tr.transform.position.y, tr.transform.position.z);
        }
        else if (collision.tag == "AirCanletLeft")
        {
            isCrash = true;
            tr.transform.position = new Vector3(tr.transform.position.x + 30, tr.transform.position.y, tr.transform.position.z);
        }
        else if (collision.tag == "AirCanRight")
        {
            isCrash = true;
            tr.transform.position = new Vector3(tr.transform.position.x - 30, tr.transform.position.y, tr.transform.position.z);
        }
        else if (collision.tag == "AirCanTop")
        {
            isCrash = true;
            tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y - 30, tr.transform.position.z);
        }
        else if (collision.tag == "AirCanBottom")
        {
            isCrash = true;
            tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y + 30, tr.transform.position.z);
        }

        if(tr.transform.localPosition.x < -450)
        {
            DestroyObject(gameObject);
            LeafManager.leftLeafs--;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCrash = false;
    }

    private void Awake()
    {
        icon = GetComponent<Image>();
        tr = GetComponent<Transform>();
    }

    void Start()
    {
        imgIndex = Random.Range(0, 6);
        icon.sprite = leafImgType[imgIndex];
    }

    IEnumerator Move(Vector3 mousePos)
    {
        Vector3 v = tr.position - Input.mousePosition;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg + 180.0f;
        tr.transform.eulerAngles = new Vector3(0, 0, angle);
        while (speed >= 0)
        {
            tr.transform.Translate(mousePos * speed * Time.deltaTime);
            speed -= 0.1f;

            yield return null;
        }

    }

}
