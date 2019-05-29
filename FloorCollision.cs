using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        var tag = collision.collider.tag;
        //Tag还需要继续补充。
        if (tag == "SnapCylinder") 
        Destroy(collision.gameObject);
    }

}
