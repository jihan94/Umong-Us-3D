    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCrtl : MonoBehaviour
{
    [SerializeField] Material bodyMat;
    [SerializeField] Material headMat;

    public float velocity = 0.0f;
    public float rotSpeed = 0.0f;
    private float hAxis = 0.0f;
    private float vAxis = 0.0f;
    private float rAxis = 0.0f;
    private bool wDown;
    private bool isDead = false;
    public bool IsDead
    {
        get { return isDead; }
    }
    private bool isFoundCorpse = false;

    [SerializeField] Rigidbody physics;
    [SerializeField] LayerMask target;

    private Animator anim;
    private Transform tr;

    public GameObject miniGameCanvas;
    public Canvas playerUI;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if (!isDead)
        {
            hAxis = Input.GetAxisRaw("Horizontal");
            vAxis = Input.GetAxisRaw("Vertical");
            rAxis = Input.GetAxis("Mouse X");
            wDown = Input.GetButtonDown("Walk");

            Vector3 moveDir = (Vector3.forward * vAxis) + (Vector3.right * hAxis);
            float vec = Vector3.Magnitude(moveDir.normalized);

            tr.Translate(moveDir.normalized * velocity * Time.deltaTime, Space.Self);
            tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * rAxis);

            anim.SetBool("isRun", moveDir != Vector3.zero);
            anim.SetBool("isWalk", wDown);

            FoundDeadBody();
        }

        if (isDead)
        {
            physics.isKinematic = true;
        }
    }

    public void DoSometing()
    {
        // UI 캔버스 부르고
        // 게임 종류를 골라서 실행시키고..
        miniGameCanvas.SetActive(true);
    }

    public void MiniGameClear()
    {
        miniGameCanvas.SetActive(false);
    }

    public void Die()
    {
        anim.SetTrigger("DoDie");
        isDead = true;
    }

    public void FoundDeadBody()
    {
        Collider[] nearCrew = Physics.OverlapSphere(transform.position, 15.0f, target);
        for (int i = 0; i < nearCrew.Length; ++i)
        {
            if (nearCrew[i].GetComponent<PlayerCrtl>().IsDead)
            {
                Debug.Log("Found");
                isFoundCorpse = true;
                //mainUi.ActiveReportIcon();
                return;
            }
        }
        isFoundCorpse = false;
        //mainUi.DeActiveReportIcon();
    }

    public void ChangeColor(Color color)
    {
        gameObject.transform.Find("Simple Player/Bone_Body/Body").GetComponent<MeshRenderer>().material.color = color;
        gameObject.transform.Find("Simple Player/Bone_Body/Bone_Shoulder_L/Bone_Arm_L/LeftHand").GetComponent<MeshRenderer>().material.color = color;
        gameObject.transform.Find("Simple Player/Bone_Body/Bone_Shoulder_R/Bone_Arm_R/RightHand").GetComponent<MeshRenderer>().material.color = color;
        gameObject.transform.Find("Simple Player/Bone_Leg_L/Bone_Foot_L/RightFoot").GetComponent<MeshRenderer>().material.color = color;
        gameObject.transform.Find("Simple Player/Bone_Leg_R/Bone_Foot_R/LeftFoot").GetComponent<MeshRenderer>().material.color = color;
        gameObject.transform.Find("Simple Player/Bone_Body/Bone_Neck/Bone_Head/Head").GetComponent<MeshRenderer>().material.color = color;
    }

}
