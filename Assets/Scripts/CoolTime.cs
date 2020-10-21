using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    public Image imageFilter;
    public Text coolTimeCounter;

    public int index;
    public float coolTime;
    private float currentCoolTime;
    private bool canUseSkill = true;
    public bool CanUseSkill
    {
        get { return canUseSkill; }
    }
    private bool isPressed;
    public bool IsPressed
    {
        get { return isPressed; }
        set { isPressed = value; }
    }

    void Start()
    {
        imageFilter.fillAmount = 0;
        StartCoroutine(CoolDown());
        currentCoolTime = coolTime;
        if(coolTimeCounter != null)coolTimeCounter.text = currentCoolTime.ToString();
        StartCoroutine(CoolTimeCounter());
        canUseSkill = false;
    }

    public void UseSkill()
    {
        if (canUseSkill)
        {
            imageFilter.fillAmount = 0;
            StartCoroutine(CoolDown());
            currentCoolTime = coolTime;
            if (coolTimeCounter != null) coolTimeCounter.text = currentCoolTime.ToString();
            StartCoroutine(CoolTimeCounter());
            canUseSkill = false;
            if(coolTimeCounter != null)coolTimeCounter.enabled = true;
        }
    }

    public void ButtonAction()
    {
        isPressed = true;
    }



    IEnumerator CoolDown()
    {
        while (imageFilter.fillAmount < 1)
        {
            imageFilter.fillAmount += 1 * Time.smoothDeltaTime / coolTime;
            yield return null;
        }
        canUseSkill = true;
        if (coolTimeCounter != null) coolTimeCounter.enabled = false;
        yield break;
    }

    IEnumerator CoolTimeCounter()
    {
        while (currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            if (coolTimeCounter != null) coolTimeCounter.text = currentCoolTime.ToString();
            currentCoolTime -= 1.0f;
        }
        yield break;
    }
}
