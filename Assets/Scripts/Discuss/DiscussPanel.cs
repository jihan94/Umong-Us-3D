using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscussPanel : MonoBehaviour
{
    [SerializeField] Canvas DiscussUI;
    [SerializeField] List<DiscussPlayerState> playerList = new List<DiscussPlayerState>();

    private void Awake()
    {
        for(int i = 0; i < playerList.Count; ++i)
        {
            playerList[i].Index = i;
        }
    }

    public void linkToPlayer()
    {
        for(int i = 0; i < 2; ++i)
        {
        }

    }

}
