using System.Collections;
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
    private float moveSpeed = 100f;
    private float rayRange = 30.0f;
    private Vector3 velocity;
    private Vector3 targetP;
    [SerializeField]
    private float smoothRotateSpeed = 180f;
    [SerializeField]
    private bool smoothRotateMode = true;
   
    public float distance=3.0f;
    

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
            velocity = Vector3.zero;
            if (Input.GetMouseButtonDown(0))
            {


                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                


                if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("field")))
                {
                    targetP = hit.point;
                    

                }
            }
            if (Vector3.Distance(transform.position, targetP) > 0.3f)
            {
                var moveDirection = (targetP - transform.position).normalized;
                agent.SetDestination(hit.point);
                

               








                animator.SetFloat("speed", targetP.magnitude);




            }
            else
            {
                animator.SetFloat("speed", 0);
            }
           
        }
    }



    
}






