using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflow : MonoBehaviour
{
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
    private Step m_step = Step.Init;
    private enum Step : int
    {
        Init = 0,   // 初期化 
        Title,      // タイトル 
        Wait,       // 待機 
        Move,       // 移動 
        Attack,     // 攻撃
        End
    }





    // Use this for initialization
    void Start()
    {
        nowChara = charaLists.Count;
        ChangeCharacter2(nowChara);
        animator = GetComponentsInChildren<Animator>();
        move = GetComponentsInChildren<mouse_Move>();

        nowplayerturn = 0;
        Debug.Log(nowplayerturn);
        
    }

 
 

    // Update is called once per frame
    void Update()
    {
        if (nowplayerturn == 0)
        {
            if (Input.GetKeyDown("q"))
            {
                ChangeCharacter2(nowChara);
            }

           
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                nowplayerturn++;
                Debug.Log(nowplayerturn);


            }
        }
        if (nowplayerturn == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                nowplayerturn--;
                Debug.Log(nowplayerturn);
            }

        }



    }







    
       
    
    
        

 

    //　操作キャラクター変更メソッド
    void ChangeCharacter2(int tempNowChara)
    {

        bool flag;  //　オン・オフのフラグ
                    //　次の操作キャラクターを指定
        int nextChara = tempNowChara + 1;
        //　次の操作キャラクターがいない時は最初のキャラクターに設定
        if (nextChara >= charaLists.Count)
        {
            nextChara = 0;
        }
        //　次の操作キャラクターだったら動く機能を有効にし、それ以外は無効にする
        for (var i = 0; i < charaLists.Count; i++)
        {

            if (i == nextChara)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            //　操作するキャラクターと操作しないキャラクターで機能のオン・オフをする
            charaLists[i].GetComponent<mouse_Move>().enabled = flag;
            //　キャラクターのアニメーションを最初の状態にする為アニメーションパラメータのSpeedを0にする
            charaLists[i].GetComponent<Animator>().SetFloat("Speed", 0);
        }
        //　次の操作キャラクターを現在操作しているキャラクターに設定して終了
        nowChara = nextChara;
    }
}


    

       


