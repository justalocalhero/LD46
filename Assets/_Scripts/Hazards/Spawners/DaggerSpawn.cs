using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public int difficulty { get { return _difficulty; } }

    public ObjectPool daggerSpawner;
    public Familiar familiar;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Fire(1);
        }
    }

    public void Fire(int wave)
    {
        int count = wave;

        for (int i = 0; i < count; i++)
        {
            GameObject go = daggerSpawner.Get();
            Dagger dagger = go.GetComponent<Dagger>();
            go.transform.position = transform.position;
            dagger.target = familiar.transform.position;

            go.SetActive(true);
        }
    }
}