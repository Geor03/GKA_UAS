using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDoorButton : MonoBehaviour
{
    public Animator PanelDoor;
    public Movs movs;
    public Text prompt;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PanelDoor.GetBool("IsOpening") == false)
            {
                PanelDoor.SetBool("IsOpening", true);
            }
            else if (PanelDoor.GetBool("IsOpening") == true)
            {
                PanelDoor.SetBool("IsOpening", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PanelDoor.GetBool("IsOpening") == false)
        {
            prompt.text = "Press E to open door";
        }
        else if (PanelDoor.GetBool("IsOpening") == true)
        {
            prompt.text = "Press E to close door";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        prompt.text = "";
    }
}
