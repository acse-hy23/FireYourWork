using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//烟花棒落地消失（SnapCylinder是啥？）
public class FloorCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        var tag = collision.collider.tag;
        if (tag == "SnapCylinder" || tag == "yanhuabang")
        Destroy(collision.gameObject);
    }

}
