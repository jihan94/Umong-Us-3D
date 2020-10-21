using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour
{
    public float rotSpeed;
    public GameObject chargedImage;
    public bool isClear = false;
    public bool IsClear
    {
        get { return isClear; }
        set { isClear = value; }
    }
    public bool isCharged = false;
    public bool IsCharged
    {
        get { return isCharged; }
        set { isCharged = value; }
    }

    private void Start()
    {
        chargedImage.SetActive(false);
    }

    public IEnumerator StartRotate()
    {
        while (!isClear)
        {
            transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator ResetRot()
    {
        float rndAngleZ = Random.Range(100, 200);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rndAngleZ);
        yield return null;
    }

    private void Update()
    {
        if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 20) isCharged = true;
        else if (transform.localEulerAngles.z > 340 && transform.localEulerAngles.z <= 360) isCharged = true;
        else isCharged = false;
        if (isCharged) chargedImage.SetActive(true);
        else if (!isCharged) chargedImage.SetActive(false);
    }

    

}
