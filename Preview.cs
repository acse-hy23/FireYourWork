using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour {
    public VRTK.VRTK_SnapDropZone other;
    public GameObject firework1;
    public GameObject firework2;
    public GameObject firework3;
    public GameObject firework4;
    public GameObject firework5;
    public GameObject firework6;
    public GameObject firework7;
    private GameObject whichone;
    private GameObject temp;
    public Tutorialmain tutorial;

    public void See() {
        whichone = other.GetCurrentSnappedObject();
        tutorial.isDone[2] = true;
        if (whichone.name.Contains("Orange"))
            temp = Instantiate(firework1);
        else if (whichone.name.Contains("Pink"))
        {
            Debug.Log("??????");
            temp = Instantiate(firework2, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (whichone.name.Contains("Blue"))
            temp = Instantiate(firework3, new Vector3(-5f, 10, 0), Quaternion.identity);
        else if (whichone.name.Contains("Green"))
            temp = Instantiate(firework4, new Vector3(-3.714f, 10, 1.077f), Quaternion.identity);
        else if (whichone.name.Contains("Hong"))
            temp = Instantiate(firework5, new Vector3(-3.714f, 10, 1.077f), Quaternion.identity);
        else if (whichone.name.Contains("Lv"))
            temp = Instantiate(firework6, new Vector3(-3.714f, 10, 1.077f), Quaternion.identity);
        else if (whichone.name.Contains("Lan")) {
            //var particle = temp.transform.Find("outer").GetComponent<ParticleSystem>();
            //var timecolor = particle.colorOverLifetime;
            //timecolor.color = Color.blue;
            temp = Instantiate(firework7, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void Stop()
    {
            Destroy(temp);
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
