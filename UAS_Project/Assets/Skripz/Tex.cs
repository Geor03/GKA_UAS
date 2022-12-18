using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tex : MonoBehaviour
{
     public Text Taimu;
     public Text Daterino;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Taimu.text = DateTime.Now.ToLongTimeString();
        Daterino.text = DateTime.Now.ToString("dd MMMM yyyy");
}
}
