using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone1 : MonoBehaviour {
    public VRTK.VRTK_SnapDropZone other;
    public GameObject firework1;
    public GameObject firework2;
    public GameObject firework3;
    public GameObject firework4;
    public GameObject firework5;
    public GameObject firework6;
    public GameObject firework7;
    private GameObject whichone;
    public Tutorialmain tutorial;

    public void See()
    {
        tutorial.isDone[20] = true;
        whichone = other.GetCurrentSnappedObject();
        if (whichone.name.Contains("Orange"))
            firework1.SetActive(true); 
        else if (whichone.name.Contains("Pink"))
            firework2.SetActive(true);
        else if (whichone.name.Contains("Blue"))
            firework4.SetActive(true);
        else if (whichone.name.Contains("Hong"))
            firework3.SetActive(true);
        else if (whichone.name.Contains("Lv"))
            firework6.SetActive(true);
        else if (whichone.name.Contains("Lan"))
            firework5.SetActive(true);
    }
    public void Stop()
    {
        tutorial.isDone[30] = true;
        if (whichone.name.Contains("Orange"))
            firework1.SetActive(false);
        else if (whichone.name.Contains("Pink"))
            firework2.SetActive(false);
        else if (whichone.name.Contains("Blue"))
            firework4.SetActive(false);
        else if (whichone.name.Contains("Hong"))
            firework3.SetActive(false);
        else if (whichone.name.Contains("Lv"))
            firework6.SetActive(false);
        else if (whichone.name.Contains("Lan"))
            firework5.SetActive(false);
    }

}
