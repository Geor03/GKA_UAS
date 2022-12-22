using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compooter : MonoBehaviour
{
    public Movs movs;
    public Light eltee;
    // Update is called once per frame

    public void Pyuteruse()
    {
        Debug.Log("Hewwo");
        if(movs.access == true && movs.compuse == true)
        {
            if(movs.opensesame == false){
                eltee.color = Color.green;
                movs.opensesame = true;
            }
            else if(movs.opensesame == true){
                eltee.color = Color.red;
                movs.opensesame = false;
            }
            
        }
        
        
    }
}
