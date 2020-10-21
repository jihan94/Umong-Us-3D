using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField] GameObject beforeVoting;
    [SerializeField] GameObject discussEffect;
    [SerializeField] Canvas emergencyDiscuss;
    [SerializeField] GameObject imposter;
    [SerializeField] DiscussPos[] discussPos = new DiscussPos[8];
    [SerializeField] GameObject alarmEffect;
    [SerializeField] GameObject crewPrefabs;

    public List<GameObject> crewList = new List<GameObject>();
    private Color[] colorArr = new Color[8];
    private AcroManager acroManager;
    private bool isDanger = false;
    public bool IsDanger
    {
        get { return isDanger; }
        set { isDanger = value; }
    }
    public bool isAcroStabilize = true;
    public int remainTime = 30;
    public int emergencyCallRemainTime = 20;

    private void Awake()
    {
        if (instance == null) instance = this;
        imposter = GameObject.Find("Imposter");
        acroManager = GameObject.Find("InteraActionObject/AcroReactor").GetComponent<AcroManager>();
        for (int i = 0; i < discussPos.Length; ++i)
        {
            discussPos[i].IndexProperty = i;
        }
        colorArr[0] = Color.yellow;
        colorArr[1] = Color.white;
        colorArr[2] = Color.green;
        colorArr[3] = Color.blue;
        colorArr[4] = Color.cyan;
        colorArr[5] = Color.magenta;
        colorArr[6] = new Color(152/255f, 102/255f, 255/255f); //연보라
        colorArr[7] = Color.red;
        GameStart();
    }

    public void GameStart()
    {
        emergencyCallRemainTime = 20;
        StartCoroutine(ReduceEmergencyCallTime());
        //for (int i = 0; i < 7; ++i)
        //{
        //    GameObject go = Instantiate(crewPrefabs, discussPos[i].transform);
        //    go.transform.position = discussPos[i].transform.position;
        //    go.GetComponent<PlayerCrtl>().ChangeColor(colorArr[i]);
        //    crewList.Add(go);
        //}
        //imposter.GetComponent<ImposterCrtl>().Index = 7;
    }


    public void StartVotPhase()
    {
        beforeVoting.SetActive(true);
        Invoke("ActiveDiscussCanvas", 2.0f);
        Invoke("VotePhase", 2.0f);
    }

    public void StartEmergencyVotePhase()
    {


    }

    public void VotePhase()
    {
        imposter.transform.position = discussPos[7].transform.position;
        for (int i = 0; i < crewList.Count; ++i)
        {
            if (crewList[i].GetComponent<PlayerCrtl>().IsDead) crewList[i].transform.position = new Vector3(10000, 10000, 10000);
        }
        //만약 투표가 끝나면 EndVotePhase 함수 호출
    }

    public void EndVotePhase()
    {
        emergencyCallRemainTime = 20;
        StartCoroutine(ReduceEmergencyCallTime());
    }


    public void ImposterWin()
    {
        Debug.Log("임포스터 승");
    }

    public void CrewWin()
    {
        Debug.Log("크루 승");
    }

    public void StartEmergencyDiscuss()
    {
        emergencyDiscuss.enabled = true;
        Invoke("DeActiveEmergencyCanvas", 2.0f);
        Invoke("ActiveDiscussCanvas", 2.0f);
        Invoke("VotePhase", 2.0f);
    }

    public void DeActiveEmergencyCanvas()
    {
        emergencyDiscuss.enabled = false;
    }

    private void ActiveDiscussCanvas()
    {
        beforeVoting.SetActive(false);
        discussEffect.SetActive(true);
        Invoke("DeActiveDiscussCanvas", 2.0f);
    }
    private void DeActiveDiscussCanvas()
    {
        discussEffect.SetActive(false);
    }

    private void MoveToVotePhase()
    {
        imposter.transform.position = discussPos[0].transform.position;
        for (int i = 0; i < crewList.Count; ++i)
        {
            if (crewList[i].GetComponent<PlayerCrtl>().IsDead) crewList[i].transform.position = new Vector3(10000, 10000, 10000);
        }
    }

    public IEnumerator ReduceEmergencyCallTime()
    {
        while (emergencyCallRemainTime > 0)
        {
            emergencyCallRemainTime -= 1;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public IEnumerator Alarm()
    {
        remainTime = 30;
        StartCoroutine(ReduceRemainTime());
        while (isDanger)
        {
            if (remainTime <= 0) ImposterWin();
            acroManager.CheckIsStabilize();
            AlarmOn();
            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator ReduceRemainTime()
    {
        while (isDanger)
        {
            remainTime -= 1;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void AlarmOn()
    {
        alarmEffect.SetActive(true);
        Invoke("AlarmOff", 0.5f);
    }

    public void AlarmOff()
    {
        alarmEffect.SetActive(false);
    }


}
