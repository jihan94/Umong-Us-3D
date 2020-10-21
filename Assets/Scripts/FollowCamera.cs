using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform mTarget;
    public Vector3 offSet;

    private Transform mInitTarget;

    private void Awake()
    {
        mInitTarget = mTarget;
    }
    void Update()
    {
        transform.position = mTarget.position + offSet;
    }

    public void ChangeTargetToVentPos(Transform target)
    {
        mTarget = target;
    }

    public void ResetTargetPos()
    {
        mTarget = mInitTarget;
    }

}
