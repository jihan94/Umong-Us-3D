using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmegencyTrigger : MonoBehaviour
{
    [SerializeField] GameObject emergencyCall;
    [SerializeField] Canvas emergencyMetting;
    private EmergencyCall emergencyMettingScripts;
    private Canvas emergencyCanvas;

    private void Awake()
    {
        emergencyCanvas = emergencyCall.GetComponent<Canvas>();
        emergencyMettingScripts = emergencyCall.GetComponent<EmergencyCall>();
        emergencyCanvas.enabled = false;
        emergencyMetting.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Imposter"))
        {
            if (other.tag == "Imposter")
            {
                other.gameObject.GetComponent<ImposterCrtl>().miniGameCanvasProperty = emergencyCanvas;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Imposter"))
        {
            if (other.tag == "Imposter")
            {
                emergencyCanvas.enabled = false;
                other.gameObject.GetComponent<ImposterCrtl>().miniGameCanvasProperty = null;
            }
        }
    }


}
