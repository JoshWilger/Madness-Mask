using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour
{
    public Animator animator;
    private string openAnim, closeAnim, defaultAnim;
    enum DoorState
    {
        Closed,
        Opened,
        Locked
    }

    DoorState doorState = new DoorState();

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        doorState = DoorState.Closed;
        openAnim = "DoorOpen";
        closeAnim = "DoorClose";
        defaultAnim = "Default";
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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(closeAnim) || animator.GetCurrentAnimatorStateInfo(0).IsName(defaultAnim))
        {
            animator.ResetTrigger("Close");
            animator.SetTrigger("Open");
            doorState = DoorState.Opened;
        }
    }

    public void CloseDoor()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(openAnim) || animator.GetCurrentAnimatorStateInfo(0).IsName(defaultAnim))
        {
            animator.ResetTrigger("Open");
            animator.SetTrigger("Close");
            doorState = DoorState.Closed;
        }
    }

    public string LockedDoor(string str)
    {
        str = "The door is locked. You need to wear a mask to open it.";
        return str;
    }

}
