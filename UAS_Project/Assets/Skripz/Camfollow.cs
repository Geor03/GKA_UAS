using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    public GameObject player;
    public Transform camTarget;
    public Movs movs;
    private Vector3 offsite;
    private float rotsped;
    public float pLerp = .01f;
    public float rLerp = .02f;
    
    // Start is called before the first frame update
    void Start()
    {
        rotsped = 50.0f;
        offsite = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        camTarget = player.transform;
        float horidawninput = Input.GetAxis("Horizontal");
        transform.position = player.transform.position + offsite;

    }
}
