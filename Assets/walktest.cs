using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class walktest : MonoBehaviour {
    RaycastHit hit;
    Ray ray;
    NavMeshAgent agent;
    Animator animator;
    Rigidbody body;
    private float moveSpeed = 100f;
    private float rayRange = 100.0f;
    private Vector3 velocity;
    private Vector3 targetP;
    [SerializeField]
    private float smoothRotateSpeed = 180f;
    [SerializeField]
    private bool smoothRotateMode = true;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        velocity = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= 0.5f)
        {

            if (Input.GetMouseButtonDown(0))
            {


                ray = Camera.main.ScreenPointToRay(Input.mousePosition);



                if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("field")))
                {
                    targetP = hit.point;

                }







                agent.SetDestination(hit.point);


                animator.SetFloat("speed", targetP.magnitude);

            }


           
        }
    }
}



