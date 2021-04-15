using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//去掉上半个球体 程序2
public class QudiaoShangmian : MonoBehaviour
{
    public VRTK.VRTK_SnapDropZone other;
    private GameObject whichone;

    public void See()
    {
        whichone = other.GetCurrentSnappedObject();
        GameObject up = whichone.transform.GetChild(1).GetChild(1).gameObject;
        GameObject lable1 = whichone.transform.GetChild(0).GetChild(2).gameObject;
        GameObject lable2 = whichone.transform.GetChild(0).GetChild(3).gameObject;
        whichone.GetComponent<SphereCollider>().isTrigger = true;
        up.SetActive(false);
        lable1.SetActive(true);
        lable2.SetActive(true);
    }
    public void Stop()
    {
        GameObject up = whichone.transform.GetChild(1).GetChild(1).gameObject;
        GameObject lable1 = whichone.transform.GetChild(0).GetChild(2).gameObject;
        GameObject lable2 = whichone.transform.GetChild(0).GetChild(3).gameObject;
        whichone.GetComponent<SphereCollider>().isTrigger = false;
        up.SetActive(true);
        lable1.SetActive(false);
        lable2.SetActive(false);
    }
}
