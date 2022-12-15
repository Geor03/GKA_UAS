using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1trigger : MonoBehaviour
{
    public Animator PanelDoor;
    private void OnTriggerEnter(Collider other)
    {
        PanelDoor.SetBool("IsOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        PanelDoor.SetBool("IsOpening", false);

    }
}
