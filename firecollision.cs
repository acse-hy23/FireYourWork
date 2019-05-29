using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firecollision : MonoBehaviour {
    public GameObject spark;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        var tag = other.tag;
        if (tag == "yanhuabang")
        {
            GameObject rootSystemGo = new GameObject("Firelalal");
            //Instantiate(spark, new Vector3(0,0,2), Quaternion.identity);
           
            rootSystemGo = GameObject.Instantiate(spark, other.transform.position, Quaternion.identity, other.transform);

        }
    }
}
