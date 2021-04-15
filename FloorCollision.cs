using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//烟花棒
public class FloorCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        var tag = collision.collider.tag;
        if (tag == "SnapCylinder" || tag == "yanhuabang")
        Destroy(collision.gameObject);
    }

}
