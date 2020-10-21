using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcroTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject acroMiniGame;
    private NuclearReactor acroMiniGameScript;
    public bool acroReactorState
    { get { return acroMiniGameScript.isStabillize; }
      set { acroMiniGameScript.isStabillize = value; }   
    }
    private Canvas acroMiniGameCanvas;

    private void Awake()
    {
        acroMiniGameCanvas = acroMiniGame.GetComponent<Canvas>();
        acroMiniGameScript = acroMiniGame.GetComponent<NuclearReactor>();
        acroMiniGameCanvas.enabled = false;
    }

    public void UnStabilizeAcro()
    {
        acroMiniGameScript.isStabillize = false;
    }

    public void ResetAcro()
    {
        acroMiniGameScript.ResetAcro();
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Imposter") && !acroMiniGameScript.isStabillize)
        {
            particle.Play();
            if (acroMiniGame == null) return;
            if (other.tag == "Imposter")
            {
                other.gameObject.GetComponent<ImposterCrtl>().miniGameCanvasProperty = acroMiniGameCanvas;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Imposter") && !acroMiniGameScript.isStabillize)
        {
            particle.Stop();
            if (acroMiniGame == null) return;
            if (other.tag == "Imposter")
            {
                acroMiniGameCanvas.enabled = false;
                other.gameObject.GetComponent<ImposterCrtl>().miniGameCanvasProperty = null;
            }
        }
    }

    

}
