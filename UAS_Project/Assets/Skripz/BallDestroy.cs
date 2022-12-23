using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallDestroy : MonoBehaviour
{
    public Animator Hatch;
    public Text prompt;
    public bool canBalls;
    public bool escape = false;
    // Start is called before the first frame update
    void Start()
    {
        canBalls = false; 
    }
    
    // Update is called once per frame
    void Update()
    {
        if(canBalls && Input.GetKeyDown(KeyCode.E))
        {
            if(!escape){
                escape = true;
            }
            else if(escape){
                escape = false;
            }
            EscapeHatch(); 
        }
    }
    void EscapeHatch()
    {
       if(escape)
       {
       Hatch.SetBool("GenDone",true);
       }
       else if(!escape)
       {
        Hatch.SetBool("GenDone",false);
       }
    }
    private void OnTriggerEnter(Collider other)
    {
        canBalls = true;
        prompt.text = "Press E to throw balls";
    }
    private void OnTriggerExit(Collider other)
    {
        canBalls = false;
        prompt.text = "";
    }
}
