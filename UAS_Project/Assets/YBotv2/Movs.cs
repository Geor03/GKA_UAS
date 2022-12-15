using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movs : MonoBehaviour
{
    float speed = 2.0f;
    float rotationSpeed = 50.0f;
    Animator anim;
    public static GameObject controlledBy;

    void Awake(){
        anim = this.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        if(controlledBy != null)return;
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.fixedDeltaTime;
        rotation *= Time.fixedDeltaTime;
        transform.Translate(0,0,translation);
        transform.Rotate(0, rotation, 0);
        if(translation !=0)
        {
            anim.SetBool("wac",true);
            anim.SetFloat("Sped", translation);
        }

        else{
            anim.SetBool("wac",false);
            anim.SetFloat("Sped",0);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            anim.SetBool("Run", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool("Run",false);
        }

    }
}
