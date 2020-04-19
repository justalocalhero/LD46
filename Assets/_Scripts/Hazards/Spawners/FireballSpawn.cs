using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public int difficulty { get { return _difficulty; } }

    public ObjectPool fireballPool;
    public ObjectPool explosionPool;

    public Familiar familiar;

    private int index, count;
    private float currentTimer;
    public float fireTime;

    private bool active;

    public void Start()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }


    public void Update()
    {
        if (!active) return;
        if (index >= count) return;
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            index++;
            currentTimer += fireTime;
            Fire();
        }
    }

    public void Fire()
    {
        GameObject go = fireballPool.Get();
        Fireball fireball = go.GetComponent<Fireball>();
        fireball.explosionPool = explosionPool;
        go.transform.position = transform.position;
        fireball.bearing = familiar.transform.position - transform.position;

        go.SetActive(true);

    }
    public void Fire(int wave)
    {
        count = 1;

        index = 0;
    }
}
