using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoroMovementScript : MonoBehaviour
{
    private Rigidbody Goro;
    public Vector2 MoveVal;
    public float moveSpeed = 8;

    private void Awake()
    {
        Goro = GetComponent<Rigidbody>();

    }
    public void Moving(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            //Debug.Log("permored");
            MoveVal = value.ReadValue<Vector2>();
            //Debug.Log(MoveVal.x + " " + MoveVal.y);
            //Goro.AddForce(new Vector3(MoveVal.x * moveSpeed, 0f, MoveVal.y * moveSpeed), ForceMode.Impulse); 

        }
        if (value.canceled)
        {
            MoveVal = value.ReadValue<Vector2>();
        }
    }




}
