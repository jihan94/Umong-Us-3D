using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGarbage : MonoBehaviour
{
    [SerializeField] Sprite[] arrImage = new Sprite[10];
    private Image icon;
    private int imgIndex;
    private float rndRotZ;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }
    private void Start()
    {
        imgIndex = Random.Range(0, 9);
        rndRotZ = Random.Range(0, 360);
        icon.sprite = arrImage[imgIndex];
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rndRotZ);
    }



}
