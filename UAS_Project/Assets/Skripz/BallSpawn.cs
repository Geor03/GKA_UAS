using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public Transform SpawnLoc;
    public GameObject Balls;
    public float BallSpawnDurat;
    public float spawnticks;
    void Start()
    {
        BallSpawnDurat = 3f;
        spawnticks = 1f;
    }
    // Update is called once per frame
    void Update()
    {
       spawnticks -= Time.deltaTime;
       if(spawnticks <= 0)
       {
        BigBalls();
        spawnticks = 0.43f;
       }

    }

    void BigBalls()
    {
    if(BallSpawnDurat >= 0)
        {
        Object.Instantiate(Balls, SpawnLoc.position, Quaternion.identity);
        BallSpawnDurat -= Time.fixedDeltaTime;
        }
    }
}
