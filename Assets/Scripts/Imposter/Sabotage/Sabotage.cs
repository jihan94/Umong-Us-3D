using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sabotage : MonoBehaviour
{
    [SerializeField] List<CoolTime> saboButtonList = new List<CoolTime>();
    [SerializeField] Canvas ownCanvs;
    private DoorManager dm;
    private AcroManager am;

    private bool isActiveSaboUI;
    public bool IsActiveSaboUI
    {
        get { return isActiveSaboUI; }
        set { isActiveSaboUI = value; }
    }


    private void Awake()
    {
        dm = GameObject.Find("DoorManager").GetComponent<DoorManager>();
        am = GameObject.Find("InteraActionObject/AcroReactor").GetComponent<AcroManager>();
        for (int i = 0; i < saboButtonList.Count; ++i)
        {
            saboButtonList[i].index = i;
        }
    }

    private void Update()
    {
        for (int i = 0; i < saboButtonList.Count; ++i)
        {
            if (saboButtonList[i].IsPressed && saboButtonList[i].CanUseSkill)
            {
                saboButtonList[i].IsPressed = false;
                saboButtonList[i].UseSkill();
                switch (i)
                {
                    case 0:
                        dm.CloseDoor(0, 1);
                        break;
                    case 1:
                        dm.CloseDoor(2, 2);
                        break;
                    case 2:
                        dm.CloseDoor(3, 3);
                        break;
                    case 3:
                        dm.CloseDoor(4, 4);
                        break;
                    case 4:
                        dm.CloseDoor(5, 7);
                        break;
                    case 5:
                        dm.CloseDoor(8, 9);
                        break;
                    case 6:
                        am.UnStabilizeAcro();
                        GameManager.instance.IsDanger = true;
                        StartCoroutine(GameManager.instance.Alarm());
                        break;
                }
                break;
            }
            else if (!saboButtonList[i].CanUseSkill) saboButtonList[i].IsPressed = false;
        }
    }

    public void DeActivThis()
    {
        ownCanvs.enabled = false;
    }

    public void ActiveThis()
    {
        ownCanvs.enabled = true;
    }    


}
