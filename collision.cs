using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {
    public GameObject prefab;
    public Tutorialmain tutorial;
    private bool kind;//如果两环星体为flase.三环星体为true。

    void Start () {
        if (transform.parent.GetChildCount() == 4)
            kind = false;
        else
            kind = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        var tag = collision.collider.tag;
        if (tag == "star")
        {
            tutorial.isDone[3] = true;
            
            Transform yanhuadan = transform.parent.parent;
            if (kind)
            {
                Transform xingti1 = transform.parent.GetChild(0);
                Transform xingti2 = transform.parent.GetChild(1);
            }
            else
            {
                Transform xingti1 = transform.parent.GetChild(0);
                Transform xingti2 = transform.parent.GetChild(1);
            }
            
            foreach (Transform trans in xingti1)
            {
                Vector3 oldposition = trans.position;
                Destroy(trans.gameObject);
                //Debug.Log("所有该脚本的物体下的子物体名称:" + trans.name);
                Quaternion newQuaternion = new Quaternion();
                newQuaternion.eulerAngles = new Vector3(90, 0, 0);
                GameObject newone = Instantiate(prefab, oldposition, newQuaternion);
                newone.tag = tag;
                newone.transform.parent = yanhuadan.transform;
            }






            //Destroy(collision.transform);
            Destroy(collision.collider);//???大概无区别
            
        }
    }
}
