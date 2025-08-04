using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isLeft;

    public SpriteRenderer spriter;

    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0);
    Quaternion leftRot = Quaternion.Euler(0, 0, -35);
    Quaternion leftRotReverse = Quaternion.Euler(0, 0, -135);
    private void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];   
    }

    private void LateUpdate()
    {
        bool isReverese = player.flipX;

        if(isLeft)
        {
            transform.localRotation = isReverese ? leftRotReverse : leftRot;
            spriter.flipY = isReverese;

            spriter.sortingOrder = isReverese ? 4 : 6;
        }

        else
        {
            transform.localPosition = isReverese ? rightPosReverse : rightPos;
            spriter.flipX = isReverese;
            spriter.sortingOrder = isReverese ? 6 : 4;
        }
    }
}
