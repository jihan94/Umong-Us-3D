using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeControl : MonoBehaviour
{
    [SerializeField] Image img = null;
    private bool isLow = true;
    public bool IsLow
    {
        get { return isLow; }
        set { isLow = value; }
    }

    private void Update()
    {
        if (isLow) img.fillAmount = Random.Range(0.1f, 0.115f);
        else img.fillAmount = Random.Range(0.8f, 0.81f);
    }

}
