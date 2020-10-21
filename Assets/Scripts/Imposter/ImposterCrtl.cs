using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImposterCrtl : MonoBehaviour
{
    [SerializeField] FollowCamera cam = null;
    [SerializeField] VentManager ventManager = null;
    [SerializeField] Vent currentVent = null;
    [SerializeField] CoolTime killCool = null;
    [SerializeField] LayerMask target = 0;

    private Collider[] colls;
    public Vent CurrentVent
    {
        get { return currentVent; }
        set { currentVent = value; }
    }
    private int index;
    public int Index
    {
        get { return index; }
        set { index = value; }
    }
    private Animator anim;
    private Transform tr;
    public Canvas miniGameCanvas = null;
    public Canvas miniGameCanvasProperty
    {
        get { return miniGameCanvas; }
        set { miniGameCanvas = value; }
    }
    Transform shortestTarget = null;
    public ImposterUI mainUi;
    public Sabotage saboUi;

    public float velocity = 0.0f;
    public float rotSpeed = 0.0f;
    private float hAxis = 0.0f;
    private float vAxis = 0.0f;
    private float rAxis = 0.0f;
    private bool wDown;
    private bool isInVent;
    private bool isInVentCol;
    private bool isFoundCorpse = false;
    private bool isOncetTab = false;
    private bool isMainUI = true;

    void Awake()
    {
        ventManager = GameObject.Find("VentManager").GetComponent<VentManager>();
        anim = GetComponentInChildren<Animator>();
        tr = GetComponent<Transform>();
        mainUi.ActiveUI();
        saboUi.DeActivThis();
    }

    void Update()
    {
        //ChangeCanvas();
        //hAxis = Input.GetAxisRaw("Horizontal");
        //vAxis = Input.GetAxisRaw("Vertical");
        //rAxis = Input.GetAxis("Mouse X");
        //wDown = Input.GetButtonDown("Walk");

        //Vector3 moveDir = (Vector3.forward * vAxis) + (Vector3.right * hAxis);
        //float vec = Vector3.Magnitude(moveDir.normalized);

        //if (!isInVent) tr.Translate(moveDir.normalized * velocity * Time.deltaTime, Space.Self);
        //if (isMainUI) tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * rAxis);

        //if (!isInVent)
        //{
        //    if (Input.GetKeyDown(KeyCode.R)) Report();
        //    anim.SetBool("isRun", moveDir != Vector3.zero);
        //    anim.SetBool("isWalk", wDown);
        //}
        //if (!isInVent && killCool.CanUseSkill && isMainUI)
        //{
        //    SearchNearCrew();

        //    if (Input.GetKeyDown(KeyCode.Mouse0) && colls.Length > 0 && !shortestTarget.GetComponent<PlayerCrtl>().IsDead)
        //    {
        //        killCool.UseSkill();
        //        KillSomeOne();
        //    }
        //}
        //if (!isInVent && isInVentCol)
        //{
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        isInVent = true;
        //        tr.transform.position = new Vector3(currentVent.transform.position.x, currentVent.transform.position.y - 1.5f, currentVent.transform.position.z);
        //    }
        //}
        //else if (isInVent)
        //{
        //    cam.ChangeTargetToVentPos(currentVent.cameraPos);
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        isInVent = false;
        //        tr.transform.position = new Vector3(currentVent.transform.position.x, currentVent.transform.position.y, currentVent.transform.position.z);
        //        cam.ResetTargetPos();
        //    }
        //    if (Input.GetKeyDown(KeyCode.Q))
        //    {
        //        ventManager.MovePrevVent(currentVent.index);
        //    }
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        ventManager.MoveNextVent(currentVent.index);
        //    }
        //}
        //FoundDeadBody();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vent")
        {
            isInVentCol = true;
            mainUi.ChangeToVent();
            currentVent = other.gameObject.GetComponentInParent<Vent>();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Vent")
        {
            isInVentCol = false;
            mainUi.ChangeToSabotage();
        }
    }

    private void SearchNearCrew()
    {
        colls = Physics.OverlapSphere(transform.position, 5.0f, target);
        float shortestTargetDistance = Mathf.Infinity;
        for (int i = 0; i < colls.Length; ++i)
        {
            float distance = Vector3.SqrMagnitude(transform.position - colls[i].transform.position);
            if (shortestTargetDistance > distance)
            {
                shortestTargetDistance = distance;
                shortestTarget = colls[i].transform;
            }
        }
    }

    private void KillSomeOne()
    {
        transform.position = shortestTarget.position;
        shortestTarget.GetComponent<PlayerCrtl>().Die();
    }

    public void FoundDeadBody()
    {
        Collider[] nearCrew = Physics.OverlapSphere(transform.position, 15.0f, target);
        for (int i = 0; i < nearCrew.Length; ++i)
        {
            if (nearCrew[i].GetComponent<PlayerCrtl>().IsDead)
            {
                isFoundCorpse = true;
                mainUi.ActiveReportIcon();
                return;
            }
        }
        isFoundCorpse = false;
        mainUi.DeActiveReportIcon();
    }

    private void Report()
    {
        if (isFoundCorpse)
        {
            GameManager.instance.StartVotPhase();
        }
    }

    private void ChangeCanvas()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isOncetTab)
        {
            mainUi.DeActiveUI();
            saboUi.ActiveThis();
            isOncetTab = true;
            isMainUI = false;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.Tab)) && isOncetTab))
        {
            saboUi.DeActivThis();
            mainUi.ActiveUI();
            isOncetTab = false;
            isMainUI = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && miniGameCanvas != null && !isInVent && isMainUI)
        {
            miniGameCanvas.enabled = true;
        }
    }



}
