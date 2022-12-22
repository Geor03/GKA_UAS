using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Movs movs;
    public bool pad = false;
    public GameObject lights1;
    public GameObject lights2;
    public GameObject lights3;
    public GameObject lights4;
    public GameObject lights5;
    public GameObject lights6;
    public GameObject lights7;
    public GameObject lights8;
    public GameObject lights9;
    public GameObject lights10;
    public GameObject lights11;
    public GameObject lights12;
    public GameObject lights13;
    public GameObject lights14;
    public GameObject lights15;
    public GameObject lights16;
    public GameObject door1;
    public GameObject door2;

    public void generator()
    {
        if (movs.access == true && movs.compuse == true)
        {
            if (pad == false)
            {
                lights1.SetActive(true);
                lights2.SetActive(true);
                lights3.SetActive(true);
                lights4.SetActive(true);
                lights5.SetActive(true);
                lights6.SetActive(true);
                lights7.SetActive(true);
                lights8.SetActive(true);
                lights9.SetActive(true);
                lights10.SetActive(true);
                lights11.SetActive(true);
                lights12.SetActive(true);
                lights13.SetActive(true);
                lights14.SetActive(true);
                lights15.SetActive(true);
                lights16.SetActive(true);
                door1.SetActive(true);
                door2.SetActive(true);
                pad = true;
            }
            else if (pad == true)
            {
                lights1.SetActive(false);
                lights2.SetActive(false);
                lights3.SetActive(false);
                lights4.SetActive(false);
                lights5.SetActive(false);
                lights6.SetActive(false);
                lights7.SetActive(false);
                lights8.SetActive(false);
                lights9.SetActive(false);
                lights10.SetActive(false);
                lights11.SetActive(false);
                lights12.SetActive(false);
                lights13.SetActive(false);
                lights14.SetActive(false);
                lights15.SetActive(false);
                lights16.SetActive(false);
                door1.SetActive(false);
                door2.SetActive(false);
                pad = false;
            }
        }
    }
}
