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

    Rigidbody2D rigid;
    SpriteRenderer spirter;
    Animator anime;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spirter = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        scanner=GetComponent<Scanner>();
        hands= GetComponentsInChildren<Hand>(true); //��Ȱ��ȭ �Ȱ͵� ���� true
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        //��ġ ����
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
}
