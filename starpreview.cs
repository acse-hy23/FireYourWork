using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starpreview : MonoBehaviour {
    public GameObject particle;
    private GameObject[] temp = new GameObject[4];
    int count=0;
    float oldtime, newtime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Body"))
        {
            oldtime = Time.time;
            count = 0;
            //Debug.Log(Time.time + ":进入该触发器的对象是：" + other.gameObject.name);
        }  
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Body"))
        {
            newtime = Time.time;
            if (newtime - oldtime > 1 && count < 4)
            {
                
                Quaternion newQuaternion = new Quaternion();
                newQuaternion.eulerAngles = new Vector3(0, 180, 0);
                temp[count]= Instantiate(particle, new Vector3(40, 30, 10), newQuaternion);
                count++;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("[VRTK][AUTOGEN]"))
        {
            foreach (GameObject star in temp)
            {
                Destroy(star);
            }
        }
    }
}
