using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;
    public float speed;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //��ġ ����
        Vector2 nextVec = inputVec.normalized*speed*Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position+nextVec);

    }
}
