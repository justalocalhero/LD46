using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public float fireTime;
    public int difficulty { get { return _difficulty; } }
    private int count, index;
    private float dx;
    private float currentTimer;

    public ObjectPool arrowSpawner;

    private bool active;

    public void Start()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }


    public void Fire(int wave)
    {
        float width = transform.localScale.x;
        count = 5 + wave / 20;
        index = 0;

        dx = width / count;
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

    private void Fire()
    {
        GameObject go = arrowSpawner.Get();
        Arrow arrow = go.GetComponent<Arrow>();
        arrow.speed += Random.Range(0, 3);
        arrow.bearing = Vector3.down;
        Vector3 position = transform.position;
        position.x += ((-(count + 1) / 2f + index) * dx);
        go.transform.position = position;

        go.SetActive(true);
        
    }
}
