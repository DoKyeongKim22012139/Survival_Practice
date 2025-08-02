using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }


    private void FixedUpdate()
    {
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);  //스크린이랑 월드 좌표 맞춰주는것
    }
}
