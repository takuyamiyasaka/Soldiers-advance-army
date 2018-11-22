using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    private Animator mywalk;
    private Rigidbody myRigidbody;
    private float Force = 800.0f;
    private float mForce = -800.0f;
    private Vector3 pos;
    GameObject[] mychara;
    GameObject currentChar;
    public int movepoint;
    public int nowplayerturn;
    public int _currentCharNum = 0;
    private int nowChara;
    //　操作可能なゲームキャラクター
    [SerializeField]
    private List<GameObject> charaLists;

    mouse_Move[] move;
    Animator[] animator;
    

    // Use this for initialization
    void Start()
    {
        mywalk = GetComponent<Animator>();

        myRigidbody = GetComponent<Rigidbody>();








    }

    // Update is called once per frame
    void Update()
    {
        ChangeCharacter(_currentCharNum);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 axis = new Vector2(x, y);
        Debug.Log(axis);
        if (Input.GetAxis("Horizontal") >= 0.5)
        {


            mywalk.SetFloat("speed", 1);

        }
        GetComponent<Rigidbody>().velocity = new Vector3(x * Force, 0, y * Force);
        Clamp();







    }
    void Clamp()
    {
        pos = transform.position; //プレイヤーの位置を取得



        pos.x = Mathf.Clamp(pos.x, transform.position.x - 5, transform.position.x + 100);//-10～+10まで
        pos.z = Mathf.Clamp(pos.z, transform.position.z - 5, transform.position.z + 100);

        transform.position = pos;
    }

    public void ChangeCharacter(int characterNum)
    {
        currentChar = mychara[characterNum];

        foreach (Animator anim in animator)
        {
            anim.SetBool("idle", false);               // いったん全キャラクターのアニメーションをデフォルトに戻す
        }

        foreach (mouse_Move ctrl in move)
        {
            ctrl.enabled = false;                       // いったん全キャラクターのスクリプトを非アクティブにする
        }

        currentChar.GetComponent<mouse_Move>().enabled = true;


        if (Input.GetMouseButtonDown(1))
        {
            if (_currentCharNum == mychara.Length - 1)
            {
                _currentCharNum = 0;
            }
            else
            {
                _currentCharNum++;
            }
            Debug.Log("Character " + _currentCharNum + " Selected");
            ChangeCharacter(_currentCharNum);
        }
    }
}
