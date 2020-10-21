using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiscussPlayerState : MonoBehaviour
{
    [SerializeField] Image deadMark;
    [SerializeField] Image votedMark;
    [SerializeField] Image idRect;
    [SerializeField] Image yesMark;
    [SerializeField] Image cancelMark;
    [SerializeField] Text playerId;

    public bool isVoted;

    private int index = 0;
    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public void Start()
    {
        isVoted = false;
        yesMark.enabled = false;
        cancelMark.enabled = false;
        deadMark.enabled = false;
        votedMark.enabled = false;
        idRect.enabled = true;
    }

    public void ApplyPlayerId(string id)
    {
        playerId.text = id;
    }


    public void ChooseThis()
    {
        if (isVoted) return;
        yesMark.enabled = true;
        cancelMark.enabled = true;
    }

    public void CancleChoose()
    {
        yesMark.enabled = false;
        cancelMark.enabled = false;
    }

    public void Voted()
    {
        cancelMark.enabled = false;
    }

    public void ActiveVotedMark()
    {
        votedMark.enabled = true;
    }

    public void ActiveDeadeMark()
    {
        deadMark.enabled = true;
    }

}
