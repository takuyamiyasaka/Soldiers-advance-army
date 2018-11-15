using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour {
    private Animator mywalk;
    private Rigidbody myRigidbody;
    private float Force = 800.0f;
    private float mForce = -800.0f;
    private Vector3 pos;


	// Use this for initialization
	void Start ()
    {
        mywalk = GetComponent<Animator>();
        
        myRigidbody = GetComponent<Rigidbody>();
        







    }
	
	// Update is called once per frame
	void Update () {
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 axis = new Vector2(x, y);
        Debug.Log(axis);
        if (Input.GetAxis("Horizontal") >= 0.5)
        {
            
            
                mywalk.SetFloat("speed", 1);
               
        }
        GetComponent<Rigidbody>().velocity = new Vector3(x*Force, 0, y*Force);
        Clamp();







    }
    void Clamp()
    {
        pos = transform.position; //プレイヤーの位置を取得



        pos.x = Mathf.Clamp(pos.x, transform.position.x-5 , transform.position.x + 100);//-10～+10まで
        pos.z = Mathf.Clamp(pos.z, transform.position.z - 5 , transform.position.z + 100);

        transform.position = pos;
    }
}
