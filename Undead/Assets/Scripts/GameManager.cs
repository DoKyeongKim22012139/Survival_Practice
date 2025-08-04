using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("#Game control")]
    public bool isLive=true;
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
    public LevelUp uiLevelUp;


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
        //임시
        uiLevelUp.Select(0);
    }
    void Update()
    {
        if (!isLive)
            return;
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTIme)
        {
            gameTime = maxGameTIme;
        }

    }

    public void GetExp()
    {
        exp++;
        if (exp == nextExp[Mathf.Min(level, nextExp.Length - 1)]) //무한레벨
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
