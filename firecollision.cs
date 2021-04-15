using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour {
    public GameObject spark;

    void OnTriggerEnter(Collider other)
    {
        var tag = other.tag;
        if (tag == "yanhuabang")
        {
            GameObject Go = new GameObject("hand-hold firework");
            Go = GameObject.Instantiate(spark, other.transform.position, Quaternion.identity, other.transform);
        }
    }
    
}
