using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMiniGame : MonoBehaviour
{
    public int clearPoint { get; set; } = 0;
    public GameObject combineMinigame;

    private void Update()
    { 
        if(clearPoint >= 4)
        {
            combineMinigame.SetActive(false);
        }
    }

    public void PointsUp()
    {
        clearPoint++;
    }

}
