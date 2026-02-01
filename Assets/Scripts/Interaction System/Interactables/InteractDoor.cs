using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween

public class InteractDoor : MonoBehaviour
{
    private Animation doorAnim;
    enum DoorState
    {
        Closed,
        Opened,
        Locked
    }

    DoorState doorState = new DoorState();

    private void Start()
    {
        doorAnim = GetComponent<Animation>();
        doorState = DoorState.Closed;
    }

    public string DoorTest(Inventory inv, string prompt)
    {
        if (doorState == DoorState.Closed && inv.hasMask)
        {
            OpenDoor();
        }

        if (doorState == DoorState.Opened && inv.hasMask)
        {
            CloseDoor();
        }

        else if (doorState == DoorState.Closed && !inv.hasMask)
        {
            LockedDoor(prompt);

        }
        return prompt;
    }

    public void OpenDoor()
    {
        if (!doorAnim.isPlaying)
        {
            doorAnim.Play("Door_Open");
            doorState = DoorState.Opened;
        }
    }

    public void CloseDoor()
    {
        if (!doorAnim.isPlaying)
        {
            doorAnim.Play("Door_Close");
            doorState = DoorState.Closed;
        }
    }

    public string LockedDoor(string str)
    {
        str = "The door is locked. You need to wear a mask to open it.";
        return str;
    }

}
