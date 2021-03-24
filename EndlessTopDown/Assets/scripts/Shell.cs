using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    private float fadeTime = 2;//timeperiod of shell lasting on the ground
    private Material mat;//Material value
    private Color originalCol;
    private float fadePercent;
    private float deathTime;

    private bool fading;
    
    void Start()
    {
        //Causes the bullets to gradually fade
        mat = GetComponent<Renderer>().material;
        originalCol = mat.color;
        deathTime = Time.time + fadeTime;
        StartCoroutine("Fade");
    }

   //conditional method for bullet fading
   IEnumerator Fade()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            if (fading)
            {
                fadePercent += Time.deltaTime;
                mat.color = Color.Lerp(originalCol, Color.clear, fadePercent);

                if (fadePercent >= 1)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (Time.time > deathTime)
                {
                    fading = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        //fades the rigidbody of the shell

        if(c.tag == "Ground")
        {
            GetComponent<Rigidbody>().Sleep();
        }
    }
}
