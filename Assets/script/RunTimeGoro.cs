using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class RunTimeGoro : MonoBehaviour
{

    private GoroMovementScript _input;
    private CharacterController _controller;
    private Animator _animator;
    [SerializeField] private float fraction; 

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<GoroMovementScript>();
        _animator = GetComponent<Animator>();


    }

    private void Update()
    {
        Movement(); 
    }

    private void Movement()
    {
        _controller.Move(new Vector3 ((_input.MoveVal.x * _input.moveSpeed)/fraction , 0f, (_input.MoveVal.y * _input.moveSpeed)/ fraction));
        _animator.SetFloat("speed",Mathf.Abs( _controller.velocity.x) + Mathf.Abs(_controller.velocity.z));
        Debug.Log(_controller.velocity.x + "" + _controller.velocity.z);

    }
}

