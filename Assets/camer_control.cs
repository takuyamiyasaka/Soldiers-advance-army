using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camer_control : MonoBehaviour {
    public GameObject knight;
    public GameObject Camera;
    public float diffrence;
    public float diffrence2;


	void Start () {
        knight = GameObject.Find("knight");
        diffrence = knight.transform.position.z- transform.position.z;
        diffrence2 = knight.transform.position.x - transform.position.x;

		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(knight.transform.position.x-diffrence2, transform.position.y,knight.transform.position.z-diffrence);

		
	}
}
