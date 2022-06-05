using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Goro2Script : MonoBehaviour
{
    float inputX;
    float inputY;

    [SerializeField] public Transform Goro;
    Animator Anim;

    Vector3 StickDirection;
    Camera MainCam;

    [SerializeField] public float damp;

    [Range(1,20)]
    [SerializeField] public float rotationSpeed;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        MainCam = Camera.main;

    }

    private void LateUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");


        StickDirection = new Vector3(inputX, 0, inputY);
        InputMove();
        InputRotation();


    }

      void  InputMove()
    {
        Anim.SetFloat("speed", Vector3.ClampMagnitude(StickDirection, 1).magnitude , damp, Time.deltaTime *10 );


    }


    void InputRotation()
    {

        Vector3 rotOfset = MainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;

        Goro.forward = Vector3.Slerp(Goro.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }
}
