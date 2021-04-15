using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour {
    public GameObject rocketemm;
    public Tutorialmain tutorial;
    public GameObject firework;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name.Contains("YHD"))
        {
            tutorial.isDone[70] = true;
            GameObject rocket = Instantiate(rocketemm);
            firework = collision.gameObject.GetComponent<FireInit>().rootSystemGo;
            firework.name = "Myfirework";
            var submodule =firework.GetComponent<ParticleSystem>().subEmitters;
            GameObject temp1 = rocket.transform.GetChild(0).gameObject;
            GameObject temp2 = rocket.transform.GetChild(1).gameObject;
            temp1.transform.SetParent(firework.transform);
            temp2.transform.SetParent(firework.transform);
            submodule.AddSubEmitter(temp1.GetComponent<ParticleSystem>(), ParticleSystemSubEmitterType.Birth, ParticleSystemSubEmitterProperties.InheritNothing);
            submodule.AddSubEmitter(temp2.GetComponent<ParticleSystem>(), ParticleSystemSubEmitterType.Death, ParticleSystemSubEmitterProperties.InheritNothing);
            Destroy(rocket);
            Destroy(collision.gameObject);
            firework.SetActive(true);
        }
    }


}
