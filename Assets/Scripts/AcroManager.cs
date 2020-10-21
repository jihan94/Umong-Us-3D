using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcroManager : MonoBehaviour
{
    [SerializeField] AcroTrigger[] acroTriggers = new AcroTrigger[2];

    public void UnStabilizeAcro()
    {
        for (int i = 0; i < 2; ++i)
        {
            acroTriggers[i].UnStabilizeAcro();
        }
        
    }

    public void CheckIsStabilize()
    {
        for (int i = 0; i < acroTriggers.Length; ++i)
        {
            if (!acroTriggers[i].acroReactorState) return;
            acroTriggers[i].ResetAcro();
        }
        GameManager.instance.IsDanger = false;
        
    }

    public void ResetAcro()
    {
        for(int i = 0; i < acroTriggers.Length; ++i)
        {
            acroTriggers[i].ResetAcro();
        }
    }    

}
