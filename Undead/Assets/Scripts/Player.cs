using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    
    public Scanner scanner;
    public Hand[] hands;
    public RuntimeAnimatorController[] animCon;

    Rigidbody2D rigid;
    SpriteRenderer spirter;
    Animator anime;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spirter = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        scanner=GetComponent<Scanner>();
        hands= GetComponentsInChildren<Hand>(true); //비활성화 된것도 포함 true
    }


    private void OnEnable()
    {
        speed*=Character.Speed;
        anime.runtimeAnimatorController = animCon[GameManager.instance.playerId];
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        //위치 제어
        Vector2 nextVec = inputVec*speed*Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position+nextVec);

    }

    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        anime.SetFloat("Speed", inputVec.magnitude);

        if(inputVec.x !=0)
        {
            spirter.flipX = inputVec.x<0;
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive)
            return;
        GameManager.instance.health -= Time.deltaTime * 10;




        if(GameManager.instance.health <0)
        {
            for(int i=2;i<transform.childCount;i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            anime.SetTrigger("Dead");
            GameManager.instance.GameOver();
        }

    }
}
