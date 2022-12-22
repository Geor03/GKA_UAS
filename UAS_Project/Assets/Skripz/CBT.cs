using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBT : MonoBehaviour
{
    
  private void OnTriggerEnter(Collider BallCrusher)
    {
        if(BallCrusher.CompareTag("No Balls"))
        {
            Destroy(gameObject);
        }
    }
}
