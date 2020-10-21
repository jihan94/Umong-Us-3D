using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EmergencyCall : MonoBehaviour
{
    [SerializeField] Image[] buttonGlass = new Image[2];
    [SerializeField] Text txt;
    private bool canEmergencyCall = false;
    private bool isPressed = false;

    private void Start()
    {
        txt.text = "크루원은 긴급회의 소집까지 \n" +
            GameManager.instance.emergencyCallRemainTime + "S\n" + " 남았습니다";
    }

    public void Update()
    {
        if (GameManager.instance.emergencyCallRemainTime > 1)
        {
            CloseTheButtonGlass();
            txt.text = "크루원은 긴급회의 소집까지 \n" +
            GameManager.instance.emergencyCallRemainTime + "S\n" + " 남았습니다";
            canEmergencyCall = false;
        }
        else
        {
            OpenTheButtonGlass();
            txt.text = "크루원의 남은 긴급회의 소집은 \n" +
                "1\n" + "번입니다";
            canEmergencyCall = true;
        }
        if(isPressed)
        {
            isPressed = false;
            GameManager.instance.StartEmergencyDiscuss();
        }

    }

    public void PressedButton()
    {
        isPressed = true;
    }

    public void OpenTheButtonGlass()
    {
        canEmergencyCall = true;
        buttonGlass[0].enabled = false;
        buttonGlass[1].enabled = true;
    }

    public void CloseTheButtonGlass()
    {
        canEmergencyCall = false;
        buttonGlass[0].enabled = true;
        buttonGlass[1].enabled = false;
    }




}
