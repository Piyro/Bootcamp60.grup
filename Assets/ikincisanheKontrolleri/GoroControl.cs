using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoroControl : MonoBehaviour
{
    Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void SahneYukle()
    {
        SceneManager.LoadScene("playground");
    }

}
