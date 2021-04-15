using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone2 : MonoBehaviour
{
    public Tutorialmain tutorial;
    public VRTK.VRTK_SnapDropZone dropzone2;
    private GameObject whichone;
    private GameObject up;
    private GameObject label1;
    private GameObject label2;
    private GameObject label3;
    private int kind;

    public void See()
    {
        tutorial.isDone[32] = true;
        whichone = dropzone2.GetCurrentSnappedObject();
        kind = whichone.transform.childCount - 1;
        up = whichone.transform.GetChild(0).GetChild(1).gameObject;
        up.SetActive(false);
        whichone.GetComponent<SphereCollider>().isTrigger = true;
        label1 = whichone.transform.GetChild(1).gameObject;
        label1.SetActive(true);
        if (kind == 2)
        {
            label2 = whichone.transform.GetChild(2).gameObject;
            label2.SetActive(true);
        }
        else if (kind == 3)
        {
            label2 = whichone.transform.GetChild(2).gameObject;
            label2.SetActive(true);
            label3 = whichone.transform.GetChild(3).gameObject;
            label3.SetActive(true);
        }
    }

    public void Stop()
    {
        whichone.GetComponent<SphereCollider>().isTrigger = false;
        up.SetActive(true);
        label1.SetActive(false);
        if(kind == 2)
        label2.SetActive(false);
        else if(kind == 3)
        label3.SetActive(false);
    }

}
