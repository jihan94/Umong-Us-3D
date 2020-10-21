using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotMiniGameTrigger: MonoBehaviour
{
    public GameObject mCanvas;

    private void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Other.gameObject.GetComponent<PlayerCrtl>().miniGameCanvas = mCanvas;
            Other.gameObject.GetComponent<PlayerCrtl>().DoSometing();
        }
    }

}
        
