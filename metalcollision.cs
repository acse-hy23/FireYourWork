using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalcollision : MonoBehaviour {
    private int child_index = 0;
    public Color mycolor;
    public Gradient jkjk;
    public Tutorialmain tutorial;
    void OnTriggerEnter(Collider collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "panel")
        {
            tutorial.isDone[50] = true;
            GameObject YHD = collision.transform.parent.gameObject;
            GameObject fireroot = YHD.GetComponent<FireInit>().rootSystemGo;
            if (collision.gameObject.name.Contains("1"))
                child_index = 0;
            else if (collision.gameObject.name.Contains("2"))
                child_index = 1;
            else if (collision.gameObject.name.Contains("3"))
                child_index = 2;
            //1:sc ..random btw 2 color
            //2:col..gradient
            //3:sc..color
            //4:sc..random color
            GameObject firework = fireroot.transform.GetChild(child_index).gameObject;
            if(firework.tag == "1")
            {
                var main = firework.GetComponent<ParticleSystem>().main;
                Color temp1 = main.startColor.colorMin;
                Color temp2 = main.startColor.colorMin;
                if (collision.gameObject.name.Contains("i"))
                    main.startColor = new ParticleSystem.MinMaxGradient(mycolor, temp1);
                else
                    main.startColor = new ParticleSystem.MinMaxGradient(temp2, mycolor);
            }

            else if(firework.tag == "2")
            {
                var colorlifetime = firework.GetComponent<ParticleSystem>().colorOverLifetime;
                var temp = colorlifetime.color.gradient;
                var keys = temp.colorKeys;
                if (collision.gameObject.name.Contains("i"))
                    keys[0].color = mycolor;
                else if (collision.gameObject.name.Contains("j"))
                    keys[1].color = mycolor;
                else if (collision.gameObject.name.Contains("k"))
                    keys[2].color = mycolor;

                temp.colorKeys = keys;
                colorlifetime.color = temp;
            }
            
            else if (firework.tag == "3")
            {
                var mianmuldule = firework.GetComponent<ParticleSystem>().main;
                mianmuldule.startColor = mycolor;
               
            }
            else if (firework.tag == "4")
            {
                var main = firework.GetComponent<ParticleSystem>().main;
                Gradient particle_color = firework.GetComponent<ParticleSystem>().main.startColor.gradient;
                var keys = particle_color.colorKeys;

                //按值传递！ 上面三行都是？
                if (firework.name=="i")
                    keys[0].color = mycolor;

                else if (firework.name==("j"))
                    keys[1].color = mycolor;

                else if (firework.name==("k"))
                    keys[2].color = mycolor;

                particle_color.colorKeys = keys;
                main.startColor = particle_color;
            }
            
            


            YHD.GetComponent<FireInit>().tihuan();
            Destroy(gameObject);
        }
    }
}
