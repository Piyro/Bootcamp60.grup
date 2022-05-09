using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class hareket : MonoBehaviour
{
    private Rigidbody capsuleRigidbody;

    public Vector2 moveVol;
    public float moveSpeed = 3;

    private void Awake()
    {
        capsuleRigidbody = GetComponent<Rigidbody>();
    }

    public void Moving(InputAction.CallbackContext Valuehareket )
    {
        if(Valuehareket.performed)
        {
            //Debug.Log("Performed");
            moveVol = Valuehareket.ReadValue<Vector2>();
            //Debug.Log(moveVol.x+" "+moveVol.y +" ");
            //capsuleRigidbody.AddForce(new Vector3(moveVol.x * moveSpeed, 0f, moveVol.y * moveSpeed), ForceMode.Impulse);
        }

        if (Valuehareket.canceled)

        {
            moveVol = Valuehareket.ReadValue<Vector2>();
        }

    }
}
