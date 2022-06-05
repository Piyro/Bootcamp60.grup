using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ucurum : MonoBehaviour
{
    [SerializeField] GameObject panel;
    bool dokunabilir = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && dokunabilir)
        {
            panel.SetActive(true);
            dokunabilir = false;
        }
    }

    public void secenek1()
    {
        Goro2Script.Anim.SetTrigger("ucurum");
        panel.SetActive(false);
    }
    public void secenek2()
    {
        panel.SetActive(false);
    }
}
