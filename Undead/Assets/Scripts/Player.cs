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


    Rigidbody2D rigid;
    SpriteRenderer spirter;
    Animator anime;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spirter = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        scanner=GetComponent<Scanner>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        //��ġ ����
        Vector2 nextVec = inputVec*speed*Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position+nextVec);

    }

    void LateUpdate()
    {
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
