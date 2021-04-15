using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//星体预览 程序4
public class starpreview : MonoBehaviour {
    public GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Body"))
        {
            particle.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Body"))
        {
            particle.SetActive(false);
        }
    }
    
}
