using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for(int i=0; i<pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        //선택한 풀의 비활성와된 오브젝트 접근
        //있으면 변수로 할당
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        
        //없으면?
        //생성하고 할당
        if(!select)
        {
            select = Instantiate(prefabs[index],transform);
            pools[index].Add(select);
        }
        return select;
    }
}
