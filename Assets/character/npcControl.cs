using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcControl : MonoBehaviour
{

    [SerializeField] GameObject destinationPoint;

    //public Transform Goro;

    private NavMeshAgent _agent;

    float mesafe;

    Animator anim;



    private void Start()
    {

       
        anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        
    }

    private void Update()
    {

        //_agent.SetDestination(destinationPoint.transform.position);

        anim.SetFloat("hiz", _agent.velocity.magnitude);

        //mesafe = Vector3.Distance(transform.position, Goro.transform.position);

        if (mesafe <= 1)
        {
            Debug.Log(mesafe);
            _agent.enabled = true;
            _agent.SetDestination(destinationPoint.transform.position);
        }

        else
        {
            _agent.enabled = false;
        }

    }

}
