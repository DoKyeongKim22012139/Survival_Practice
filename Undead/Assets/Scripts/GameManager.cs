using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime;
    public float maxGameTIme=2*10f;



    public Player player;
    public PoolManager pool;



    void Awake()
    {
        instance = this;
    }

    void Update()
    {

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTIme)
        {
            gameTime = maxGameTIme;
        }

    }

}
