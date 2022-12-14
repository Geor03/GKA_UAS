using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movs : MonoBehaviour
{
   public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    Animator anim;

    void Awake(){
        anim = this.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
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
        // else if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     anim.setBool("isJumping",true);
        // }

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
