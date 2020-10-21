using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScripts : MonoBehaviour
{
    [SerializeField] Transform door;

    private int index;
    public int IndexProperty
    {
        get { return index; }
        set { index = value; }
    }

    public void CloseDoor()
    {
        door.Rotate(0,-90,0);
        Invoke("OpenDoor", 5.0f);
    }
    
    public void OpenDoor()
    {
        door.Rotate(0,90,0);
    }

}
