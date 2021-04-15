using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInit : MonoBehaviour
{
    public GameObject prefab;
    public GameObject rootSystemGo;
    private int kind;
    private int child_index;
    private float seconds = 0; //倒计时时间
    void Start()
    {
        rootSystemGo = Instantiate(prefab);
        rootSystemGo.SetActive(false);
        kind = rootSystemGo.transform.childCount;
        Setcolor();
    }

    void Setcolor()
    {
        for (int i = 0; i < kind; i++)
        {

            //1:sc ..random btw 2 color
            //2:col..gradient
            //3:sc..color
            //4:sc..random color
            Transform obj = transform.GetChild(i + 1);

            if (rootSystemGo.transform.GetChild(i).tag == "1")
            {
                Color a = rootSystemGo.transform.GetChild(i).GetComponent<ParticleSystem>().main.startColor.colorMin;
                Color b = rootSystemGo.transform.GetChild(i).GetComponent<ParticleSystem>().main.startColor.colorMax;
                StartCoroutine(Setcolor2(a, b, obj));
            }

            else if (rootSystemGo.transform.GetChild(i).tag == "2")
            {
                ParticleSystem.MinMaxGradient particle_color = rootSystemGo.transform.GetChild(i).GetComponent<ParticleSystem>().colorOverLifetime.color;
                GradientColorKey[] colorKeys = particle_color.gradient.colorKeys;
                int count = colorKeys.Length;
                Color color1 = colorKeys[0].color;
                Color color2 = colorKeys[1].color;
                if (count == 3)
                {
                    Color color3 = colorKeys[2].color;
                    StartCoroutine(Setcolor3(color1, color2, color3, obj));
                }
                else
                    StartCoroutine(Setcolor2(color1, color2, obj));
            }

            else if (rootSystemGo.transform.GetChild(i).tag == "3")
            {
                Color a = rootSystemGo.transform.GetChild(i).GetComponent<ParticleSystem>().main.startColor.color;
                var renderers = obj.GetComponentsInChildren<MeshRenderer>();
                foreach (var renderer in renderers)
                    renderer.material.color = a;
            }

            else if (rootSystemGo.transform.GetChild(i).tag == "4") {
                ParticleSystem.MinMaxGradient particle_color = rootSystemGo.transform.GetChild(i).GetComponent<ParticleSystem>().main.startColor;
                GradientColorKey[] colorKeys = particle_color.gradient.colorKeys;
                int count = colorKeys.Length;
                Color color1 = colorKeys[0].color;
                Color color2 = colorKeys[1].color;
                if (count == 3)
                {
                    Color color3 = colorKeys[2].color;
                    StartCoroutine(Setcolor3(color1, color2, color3, obj));
                }
                else
                    StartCoroutine(Setcolor2(color1, color2, obj));
            }






        }
    }

    IEnumerator Setcolor2(Color color1, Color color2, Transform obj)
    {
        float seconds = 0; //倒计时时间

        if (obj.name.Contains("1"))
            child_index = 0;
        else if (obj.name.Contains("2"))
            child_index = 1;
        else if (obj.name.Contains("3"))
            child_index = 2;



        while (true)
        {
            seconds += Time.deltaTime;
            float t1 = 1f; //停顿的时间
            float t2 = 0.7f;//渐变的时间
            float t3 = 1 / t2;

            if (seconds < t1)
            {
                rootSystemGo.transform.GetChild(child_index).name = "i";
                ChangeColor(obj, color1);
            }

            else if (seconds >= t1 && seconds < t1 + t2)
                ChangeColor(obj, Color.Lerp(color1, color2, (seconds - t1) * t3));

            else if (seconds >= t1 + t2 && seconds < 2 * t1 + t2)
            {
                rootSystemGo.transform.GetChild(child_index).name = "j";
                ChangeColor(obj, color2);
            }

            else if (seconds >= 2 * t1 + t2 && seconds < 2 * t1 + 2 * t2)
                ChangeColor(obj, Color.Lerp(color2, color1, (seconds - (2 * t1 + t2)) * t3));

            else if (seconds > 2 * t1 + 2 * t2)
                seconds = 0f;
            yield return 0;
        }
    }

    IEnumerator Setcolor3(Color color1, Color color2, Color color3, Transform obj)
    {
        

        if (obj.name.Contains("1"))
            child_index = 0;
        else if (obj.name.Contains("2"))
            child_index = 1;
        else if (obj.name.Contains("3"))
            child_index = 2;

        while (true)
        {
            seconds += Time.deltaTime;
            float t1 = 1f; //停顿的时间
            float t2 = 0.7f;//渐变的时间
            float t3 = 1 / t2;
            if (seconds < t1)
            {
                rootSystemGo.transform.GetChild(child_index).name = "i";
                ChangeColor(obj, color1);
            }
            else if (seconds >= t1 && seconds < t1 + t2)
                ChangeColor(obj, Color.Lerp(color1, color2, (seconds - t1) * t3));

            else if (seconds >= t1 + t2 && seconds < 2 * t1 + t2)
            {
                rootSystemGo.transform.GetChild(child_index).name = "j";
                ChangeColor(obj, color2);
            }
            else if (seconds >= 2 * t1 + t2 && seconds < 2 * t1 + 2 * t2)
                ChangeColor(obj, Color.Lerp(color2, color3, (seconds - (2 * t1 + t2)) * t3));

            else if (seconds >= 2 * t1 + 2 * t2 && seconds < 3 * t1 + 2 * t2)
            {
                rootSystemGo.transform.GetChild(child_index).name = "k";
                ChangeColor(obj, color3);
            }
            else if (seconds >= 3 * t1 + 2 * t2 && seconds < 3 * t1 + 3 * t2)
                ChangeColor(obj, Color.Lerp(color3, color1, (seconds - (3 * t1 + 2 * t2)) * t3));

            else if (seconds > 3 * t1 + 3 * t2)
                seconds = 0f;
            yield return 0;
        }
    }

    void ChangeColor(Transform obj, Color color) {
        var renderers = obj.GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers) {
            renderer.material.color = color;
        }
    }

    public void tihuan() {
        StopAllCoroutines();
        Setcolor();
    }

}