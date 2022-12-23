using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDoorButton : MonoBehaviour
{
    public Animator Door;
    protected bool canOpen = false;
    public Movs movs;
    public Text prompt;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen == true)
        {
            if (Door.GetBool("Opening")==false){
                Door.SetBool("Opening", true);
            }
            else if (Door.GetBool("Opening")==true){
                Door.SetBool("Opening", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canOpen = true;
        if(Door.GetBool("Power")==true){
            if (Door.GetBool("Opening")==false)
            {
                prompt.text = "Press E to open door";
            }
            else if (Door.GetBool("Opening")==true)
            {
                prompt.text = "Press E to close door";
            }
        }
        else if(Door.GetBool("Power")==false){
            prompt.text = "Need power to close/open door";

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
        prompt.text = "";
    }
}
