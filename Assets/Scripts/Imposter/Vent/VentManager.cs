using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentManager : MonoBehaviour
{
    [SerializeField] List<Vent> allVent = new List<Vent>();
    [SerializeField] ImposterCrtl imposter = null;

    private void Awake()
    {
        for(int i = 0; i < allVent.Count; ++i)
        {
            allVent[i].index = i;
        }
        //imposter = GameObject.Find("Imposter").GetComponent<ImposterCrtl>();
    }

    public void MoveNextVent(int current)
    {
        if (current >= allVent.Count -1) return;
        current++;
        imposter.CurrentVent = allVent[current];
    }
    public void MovePrevVent(int current)
    {
        if (current <= 0) return;
        current--;
        imposter.CurrentVent = allVent[current];
    }

}
