﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mouse_Move : MonoBehaviour
{

    RaycastHit hit;
    Ray ray;
    NavMeshAgent agent;

    Animator animator;
    Rigidbody body;
    private float moveSpeed = 1.5f;
    private float rayRange = 100.0f;
    private Vector3 velocity;
    private Vector3 targetP;
    [SerializeField]
    private float smoothRotateSpeed = 180f;
    [SerializeField]
    private bool smoothRotateMode = true;
    private Vector3 knight;
    public float distance = 3.0f;
    private CharacterController characterController;
    private bool isControl;
    public int playerturn;
    public GameObject nowturn;
    public int nextturn;


    // Use this for initialization
    void Start()
    {


        agent = GetComponent<NavMeshAgent>();



        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
        knight = transform.position;
        int nowturn = GameObject.Find("Turnmanager").GetComponent<turnmanager>().nowplayerturn;
        playerturn = nowturn;
        Debug.Log("今" + playerturn + "ターン");
        

    }



    // Update is called once per frame
    void Update()
    {
        if (playerturn == 0)
        {
            if (this.transform.position.y <= 0.5f)
            {

                velocity = Vector3.zero;
                if (Input.GetMouseButtonDown(0))
                {
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("field")))
                    {
                        targetP = hit.point;

                    }
                }


                if (Vector3.Distance(knight, targetP) < 15.0f && targetP != Vector3.zero)
                {
                    var moveDirection = (targetP - transform.position).normalized;
                    agent.SetDestination(hit.point);
                    if (smoothRotateMode)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z)), Time.deltaTime);

                    }

                    animator.SetFloat("speed", targetP.magnitude);
                }
                if (Vector3.Distance(transform.position, targetP) < 1f)
                {
                    animator.SetFloat("speed", 0);
                    Returnturn();
                }

            }




        }
    }





    public void Returnturn()
    {
        
        turnmanager t = new turnmanager();
        playerturn = 1;
        t.nowplayerturn = playerturn;
        nextturn = t.nowplayerturn;
        Debug.Log("次のターンは" + nextturn + "です。");

    }
}

    

            
        
    

           
    



    
    







    
        









