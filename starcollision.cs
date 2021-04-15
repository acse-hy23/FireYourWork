using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starcollision : MonoBehaviour
{
    public Tutorialmain tutorial;
    public GameObject particle_preview;//星体模型
    public GameObject particle;//用于替换的真正粒子
    private int child_index=0;

    void OnTriggerEnter(Collider collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "panel")
        {
            tutorial.isDone[40] = true;
            GameObject YHD = collision.transform.parent.gameObject;
            GameObject firework = YHD.GetComponent<FireInit>().rootSystemGo;
            if (collision.gameObject.name.Contains("1"))
                child_index = 0;
            else if (collision.gameObject.name.Contains("2"))
                child_index = 1;
            else if (collision.gameObject.name.Contains("3"))
                child_index = 2;
            Destroy(gameObject);
            GameObject but = collision.gameObject;
            List<Transform> butArray = new List<Transform>(); ;
            foreach (Transform child in but.transform)
            {
                butArray.Add(child);
            }
            foreach (Transform trans in butArray)
            {
                Vector3 oldposition = trans.position;
                Destroy(trans.gameObject);
                Quaternion newQuaternion = new Quaternion();
                newQuaternion.eulerAngles = new Vector3(90, 0, 0);
                GameObject newone = Instantiate(particle_preview, oldposition, newQuaternion, collision.gameObject.transform);
                newone.transform.localScale = new Vector3(1, 1, 1);
            }
            GameObject oldparticle = firework.transform.GetChild(child_index).gameObject;
            
            GameObject newparticle = Instantiate(particle,firework.transform);
            newparticle.transform.SetSiblingIndex(child_index);
            var aha = newparticle.GetComponent<ParticleSystem>().main;
            aha.startSpeed = oldparticle.GetComponent<ParticleSystem>().main.startSpeed;
            aha.startSize = oldparticle.GetComponent<ParticleSystem>().main.startSize;

            Destroy(firework.transform.GetChild(child_index).gameObject);

            YHD.GetComponent<FireInit>().tihuan();
        }
    }
}
