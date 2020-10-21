using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] List<DoorScripts> doorList = new List<DoorScripts>();

    private void Awake()
    {
        for(int i = 0; i < doorList.Count; ++i)
        {
            doorList[i].IndexProperty = i;
        }
        AllDoorOpen();
    }

    public void CloseDoor(int minIndex, int maxIndex)
    {
        for(int i = minIndex; i < maxIndex + 1; ++i)
        {
            Debug.Log(i + "인덱스 :" + doorList[i].IndexProperty);
            doorList[i].CloseDoor();
        }
    }

    public void AllDoorOpen()
    {
        for(int i = 0; i < doorList.Count; ++i)
        {
            doorList[i].OpenDoor();
        }
    }
}
