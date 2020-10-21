using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GarbageManger : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject garbagePrefab = null;
    [SerializeField] GameObject bg = null;
    [SerializeField] GameObject lever = null;
    [SerializeField] GameObject openCol = null;
    [SerializeField] Image bar = null;
    private List<GameObject> garbages = new List<GameObject>();
    private bool isPull;
    private bool isClear = false;
    private float rndPosX;
    private float rndPosY;
    private float minPosY;
    private float maxPosY;
    private Vector3 backUpLeverPos;
    private Vector3 initPos;

    private void Awake()
    {
        for (int i = 0; i < 20; ++i)
        {
            GameObject go = Instantiate(garbagePrefab, bg.transform);
            garbages.Add(go);
        }
        backUpLeverPos = lever.transform.position;
        minPosY = transform.Find("Bg/LeverBase/MinPos").transform.position.y;
        maxPosY = backUpLeverPos.y;
    }

    private void Start()
    {
        initPos = bg.transform.position;
        isPull = false;
        for (int i = 0; i < garbages.Count; ++i)
        {
            rndPosX = Random.Range(-250, 100);
            rndPosY = Random.Range(-100, 200);
            garbages[i].transform.localPosition = new Vector3(rndPosX, rndPosY, garbages[i].transform.position.z);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.transform.position = backUpLeverPos;
        bar.fillAmount = 1f;
        openCol.SetActive(true);
        bg.transform.position = initPos;
        isPull = false;
        DeleteGarbage();
        if (isClear) gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        isPull = true;
        Vector3 finalPos = new Vector3(lever.transform.position.x, Input.mousePosition.y, lever.transform.position.z);
        if (backUpLeverPos.y < finalPos.y)
        {
            finalPos.y = backUpLeverPos.y;
        }
        else if (minPosY > Input.mousePosition.y) finalPos.y = minPosY;
        lever.transform.position = finalPos;

        float maxRange = maxPosY - minPosY;
        float currentRange = finalPos.y - minPosY;
        
        float ratio = currentRange / maxRange;
        bar.fillAmount = ratio;

        StartCoroutine(ShakeBg());

        if(bar.fillAmount <= 0)openCol.SetActive(false);
    }

    private void DeleteGarbage()
    {
        for(int i = 0; i < garbages.Count; ++i)
        {
            if(garbages[i].transform.position.y < openCol.transform.position.y)
            {
                garbages[i].SetActive(false);
            }
        }
        IsClear();
    }

    IEnumerator ShakeBg()
    {
        while(isPull)
        {
            bg.transform.position = Random.insideUnitSphere * 10 + initPos;
            yield return null;
        }
    }

    private void IsClear()
    {
        for(int i = 0; i < garbages.Count; ++i)
        {
            if (garbages[i].activeSelf == true) return;
        }
        isClear = true;
    }
}
