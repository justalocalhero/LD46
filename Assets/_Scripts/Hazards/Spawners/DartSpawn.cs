using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public int difficulty { get { return _difficulty; } }

    public ObjectPool dartSpawner;
    private float height;
    private int count;
    private int index;
    private float currentTimer;
    public float fireTime;

    public void Update()
    {
        if (index >= count) return;
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            index++;
            currentTimer += fireTime;
            Fire();
        }
    }

    public void Fire(int wave)
    {
        height = transform.localScale.y;
        count = 3 + wave / 20;

        index = 0;
    }

    public void Fire()
    {
        float dy = Random.Range(-height / 2, height / 2);

        int flipFacing = Random.Range(-1, 1);
        int facing = (flipFacing == 0) ? -1 : 1;

        GameObject go = dartSpawner.Get();
        Dart dart = go.GetComponent<Dart>();
        dart.bearing = new Vector3(-facing, 0, 0);

        Vector3 localScale = go.transform.localScale;
        localScale.x = facing * .5f;
        go.transform.localScale = localScale;

        Vector3 position = transform.position;
        position.x = position.x * facing;
        position.y += dy;
        go.transform.position = position;

        go.SetActive(true);

    }
}
