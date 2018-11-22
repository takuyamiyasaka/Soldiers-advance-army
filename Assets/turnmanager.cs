using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class turnmanager : MonoBehaviour
{
    public GameObject[] charas;
    public int nowplayerturn = 0;
    public int nextturn;
    public GameObject nextnext;
   
    // Use this for initialization
    public void Start()
    {
       
    }
      
    // Update is called once per frame
    void Update()
    {
        
        {
            
        }
    }
    public void Sendturn()
    {

        int nextnext = GameObject.Find("knight").GetComponent<mouse_Move>().nextturn;

        Debug.Log(nextnext);
    }
    private void Nowturn()
    {
        nowplayerturn = 0;
    }
  
}
