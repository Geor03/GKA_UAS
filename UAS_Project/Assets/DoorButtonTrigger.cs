using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorButtonTrigger : MonoBehaviour
{
    public Animator PanelDoor;
    protected bool canOpen = false;
    public Movs movs;
    public Text prompt;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen == true && movs.access)
        {
            if(PanelDoor.GetBool("IsOpening")==false){
                PanelDoor.SetBool("IsOpening", true);
            }
            else if(PanelDoor.GetBool("IsOpening")==true){
                PanelDoor.SetBool("IsOpening", false);
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        canOpen = true;
        if(movs.access){
            if(PanelDoor.GetBool("IsOpening")==false){
                prompt.text = "Press E to open door";
            }
            else if(PanelDoor.GetBool("IsOpening")==true){
                prompt.text = "Press E to close door";
            }
        }
        else
            prompt.text = "I want Green Light";
        
    }

    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
        prompt.text = "";

    }
}
