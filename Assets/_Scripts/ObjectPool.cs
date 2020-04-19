using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject toPool;
    public int numberToPool;

    public Queue<GameObject> pool = new Queue<GameObject>();

    public void Start()
    {
        for(int i = 0; i < numberToPool; i++)
        {
            GameObject toEnqueue = Instantiate(toPool);
            toEnqueue.SetActive(false);
            pool.Enqueue(toEnqueue);
        }
    }

    public GameObject Get()
    {
        GameObject toReturn = pool.Dequeue();
        pool.Enqueue(toReturn);

        return toReturn;
    }

    public void Kill()
    {
        foreach(GameObject go in pool)
        {
            go.SetActive(false);
        }
    }
}
