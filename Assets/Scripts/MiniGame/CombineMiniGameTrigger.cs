using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMiniGameTrigger : MonoBehaviour
{
    public GameObject mCanvas;

    private void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Other.gameObject.GetComponent<PlayerCrtl>().miniGameCanvas = mCanvas;
                Other.gameObject.GetComponent<PlayerCrtl>().DoSometing();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerCrtl>().miniGameCanvas == null) return;
            other.gameObject.GetComponent<PlayerCrtl>().miniGameCanvas.SetActive(false);
            other.gameObject.GetComponent<PlayerCrtl>().miniGameCanvas = null;
        }
    }
}
