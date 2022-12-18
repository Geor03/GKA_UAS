using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movs : MonoBehaviour
{
    float speed = 2.0f;
    float rotationSpeed = 100.0f;
    Animator anim;
    public static GameObject controlledBy;
    public bool canpick = false;
    public bool access = false;
    public bool compuse = false;
    public bool opensesame = false;
    public GameObject Card;
    public Compooter pooter;
    public Text prompt;
    
    void Awake(){
        anim = this.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        if(controlledBy != null) return;
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

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(canpick == true)
            {
            KardPickup52();
            }
            if(compuse == true && access == true)
            {
            pooter.Pyuteruse();
            }

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

    void OnTriggerEnter(Collider pick)
    {
        if(pick.CompareTag("Kard"))
        {
            canpick = true;
            prompt.text = "Press EEEEEEE to pick up Card";
        }
        if(pick.CompareTag("Pooter") )
        {
          if(access)
          {
           if(!opensesame)
           {
           compuse = true;
           prompt.text = "Press EEEEEEE to use the Pyuter";
           }
          }
          else if(!access)
          {
             prompt.text = "No Kard No Service";
          }
        }
    }
    void OnTriggerExit(Collider pick)
    {
        if(pick.CompareTag("Kard"))
        {
            canpick = false;
            prompt.text = "";
        }
        if(pick.CompareTag("Pooter"))
        {
           compuse = false;
           prompt.text = "";
        }
    }

    void KardPickup52()
    {
        Debug.Log("Herro");
            access = true;
            Destroy(Card);
            prompt.text = "";
        
    }
}
