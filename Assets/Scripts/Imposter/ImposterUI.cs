using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImposterUI : MonoBehaviour
{
    [SerializeField] Transform ventCamPos;
    [SerializeField] Canvas ownCanvas;
    [SerializeField] Sprite[] changeIcon;
    [SerializeField] Image sabotageIcon;
    [SerializeField] Image reportIcon;
    [SerializeField] Text remainTime;

    private void Awake()
    {
        reportIcon.color = Color.gray;
    }

    private void Update()
    {
        if (GameManager.instance.IsDanger) ActiveRemainTime();
        else DeActiveRemainTime();
    }

    public void ChangeToVent()
    {
        sabotageIcon.sprite = changeIcon[0];
    }
    public void ChangeToSabotage()
    {
        sabotageIcon.sprite = changeIcon[1];
    }
    public void ChangeToUse()
    {
        sabotageIcon.sprite = changeIcon[2];
    }

    public void ActiveReportIcon()
    {
        reportIcon.color = Color.white;
    }

    public void DeActiveReportIcon()
    {
        reportIcon.color = Color.gray;
    }

    public void DeActiveUI()
    {
        ownCanvas.enabled = false;
    }

    public void ActiveUI()
    {
        ownCanvas.enabled = true;
    }

    public void ActiveRemainTime()
    {
        remainTime.enabled = true;
        remainTime.text = GameManager.instance.remainTime.ToString();
    }

    public void DeActiveRemainTime()
    {
        remainTime.enabled = false;
    }

    private void ChangetTextColorToRed()
    {
        remainTime.color = new Color(255, 0, 0);
        Invoke("ChangeTextColorToYellow", 2.0f);
    }

    private void ChangeTextColorToYellow()
    {
        remainTime.color = new Color(255, 255, 0);
        Invoke("ChangeTextColorToRed", 2.0f);
    }

}
