using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("#Game control")]
    public float gameTime;
    public float maxGameTIme=2*10f;

    [Header("#Play info")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };

    [Header("#GameObj")]
    public Player player;
    public PoolManager pool;



    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }
    void Update()
    {

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTIme)
        {
            gameTime = maxGameTIme;
        }

    }

    public void GetExp()
    {
        exp++;
        if(exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
}
