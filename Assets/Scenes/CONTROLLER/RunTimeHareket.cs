using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(PlayerInput))]


public class RunTimeHareket : MonoBehaviour
{
    private hareket _input;
    private CharacterController _controller;
    private Animator _animator;
    [SerializeField] private float yuzdelik;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<hareket>();
        _animator = GetComponent<Animator>();
        

    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _controller.Move(new Vector3( (_input.moveVol.x * _input.moveSpeed)/yuzdelik, 0f, (_input.moveVol.y * _input.moveSpeed)/yuzdelik));
        _animator.SetFloat("speed", Mathf.Abs(_controller.velocity.x) + Mathf.Abs(_controller.velocity.z));
        Debug.Log(_controller.velocity.x + "" + _controller.velocity.z );
      
    }
}
