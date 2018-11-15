using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk2 : MonoBehaviour
{
    private Animator mywalk;
    private Rigidbody body;
    private Vector3 velocity;
    private float force = 10.0f;
    private float rayRange = 100f;
    private Vector3 targetP;
    [SerializeField]
    private bool MouseDownMode = true;
    private LayerMask terrain;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        mywalk = GetComponent<Animator>();
        targetP = transform.position;
        velocity = Vector3.zero;


    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 axis = new Vector2(x, y);
        Debug.Log(axis);
        if (this.transform.position.y < 1.0f)
        {

            if (MouseDownMode)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("Terrain")))
                {
                    targetP = hit.point;

                    mywalk.SetFloat("speed", 1);
                    GetComponent<Rigidbody>().velocity = new Vector3(x * force, 0, y * force);
                    transform.LookAt(transform.position + velocity);

                }
            }
            velocity = new Vector3(x, 0, y);
            if (velocity.magnitude > 0)
            {
                mywalk.SetFloat("speed", 1);
                GetComponent<Rigidbody>().velocity = new Vector3(x * force, 0, y * force);
                transform.LookAt(transform.position + velocity);
                if (Input.GetMouseButtonDown(0))
                {
                    if (Vector3.Distance(transform.position, targetP) > 0.1f)
                    {
                        var moveDirection = (targetP - transform.position).normalized;
                        velocity = new Vector3(moveDirection.x * force, velocity.y, moveDirection.z * force);
                        mywalk.SetFloat("speed", 1);
                        body.velocity = new Vector3(x, 0, y);

                        body.AddForce(transform.forward * force);
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        GetComponent<Animator>().SetFloat("speed", 0);
                    }


                }
            }
            else

                mywalk.SetFloat("speed", 0);

        }
    }
}
       




        

    
    

