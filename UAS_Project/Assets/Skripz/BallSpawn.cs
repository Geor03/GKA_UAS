using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawn : MonoBehaviour
{
    public Transform SpawnLoc;
    public Animator Hatch;
    public GameObject Balls;
    public float BallSpawnDurat;
    public float spawnticks;
    public Text prompt;
    public bool canBalls;
    public bool flowBalls;
    public bool escape = false;
    void Start()
    {
        canBalls = false;
        BallSpawnDurat = 0f;
        spawnticks = 0f;
        flowBalls = false;
    }
    // Update is called once per frame
    void Update()
    {
       if(canBalls && Input.GetKeyDown(KeyCode.E))
       {
        initbruv();
         flowBalls = true;
       }
       if(canBalls && Input.GetKeyDown(KeyCode.F))
       {
        if(!escape){
        escape = true;
        }
        else if(escape){
        escape = false;
        }
        EscapeHatch();
        
       }
       if(spawnticks >= 0)
       {
         spawnticks -= Time.deltaTime;
       }
       else if(spawnticks < 0.1f && flowBalls)
       {
        Debug.Log("Balls");
        BigBalls();
        spawnticks = 0.43f;
       }

    }

    void initbruv()
    {
        BallSpawnDurat = 1f;
        spawnticks = 1f;
    }
    
    void BigBalls()
    {
    if(BallSpawnDurat >= 0)
        {
        Object.Instantiate(Balls, SpawnLoc.position, Quaternion.identity);
        BallSpawnDurat -= Time.fixedDeltaTime;
       
        }
    else
    {
        flowBalls = false;
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
        
         prompt.text = "Press EEEEEEE to balls Press F to pay respects";
      
        
    }

    private void OnTriggerExit(Collider other)
    {
        canBalls = false;
         prompt.text = "";
        
    }
}
