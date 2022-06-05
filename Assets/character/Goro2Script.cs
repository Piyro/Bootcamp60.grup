using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goro2Script : MonoBehaviour
{
    float inputX;
    float inputY;
    bool dusebilir = true;
    bool degebilir = true;

    public Light sezgi;
    public bool acik;


    [SerializeField] public Transform Goro;
    public static Animator Anim;

    Vector3 StickDirection;
    Camera MainCam;

    [SerializeField] public float damp;
    float speed = 1;

    [Range(1, 20)]
    [SerializeField] public float rotationSpeed;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        MainCam = Camera.main;
        sezgi.enabled = false;



    }

    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        StickDirection = new Vector3(inputX, 0, inputY);
        InputMove();


    }

    private void LateUpdate()
    {
        InputRotation();
    }

    void InputMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2;
        }
        else
        {
            speed = 1;
        }

        Anim.SetFloat("speed", Vector3.ClampMagnitude(StickDirection, speed).magnitude, damp, Time.deltaTime * 10);
    }

    void InputRotation()
    {
        Vector3 rotOfset = MainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;

        Goro.forward = Vector3.Slerp(Goro.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("rock"))
        {
            if (dusebilir == true)
            {
                Anim.SetTrigger("dustu");
                StartCoroutine(Dusmesin());
            }
        }

        if (collision.gameObject.CompareTag("dusman"))
        {
            if (degebilir == true)
            {
                Anim.SetTrigger("degdi");
                StartCoroutine(Kacsin());
            }

        }

        if (collision.gameObject.CompareTag("sezgi"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(isik());
        }

        if (collision.gameObject.CompareTag("ucurum"))
        {
            
            {
                Anim.SetTrigger("ucurum");

            }
            
        }


    }



    private IEnumerator Dusmesin()
    {
        dusebilir = false;
        yield return new WaitForSeconds(3f);
        dusebilir = true;
    }

    private IEnumerator Kacsin()
    {
        degebilir = false;
        yield return new WaitForSeconds(4f);
        degebilir = true;
    }

    private IEnumerator isik()
    {

            sezgi.enabled = true;
            yield return new WaitForSeconds(2f);
            sezgi.enabled = false;
        
    }
       
    
}