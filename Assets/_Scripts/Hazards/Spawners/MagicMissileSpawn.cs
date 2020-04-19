using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissileSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public int difficulty { get { return _difficulty; } }

    public ObjectPool dartSpawner;
    public Familiar familiar;

    private int index, count;
    public float fireTime;
    private float currentTimer;
    float height;
    int facingX, facingY;

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
        float dy = Random.Range(-height / 2, height / 2);

        GameObject go = dartSpawner.Get();
        MagicMissile missile = go.GetComponent<MagicMissile>();
        missile.targetTransform = familiar.transform;
        Vector3 position = transform.position;

        position.x = position.x * facingX;
        position.y = position.y * facingY;

        go.transform.position = position;

        Vector3 localScale = go.transform.localScale;
        localScale.x = facingX * .25f;
        localScale.y = facingY * .25f;
        go.transform.localScale = localScale;

        go.SetActive(true);
    }

    public void Fire(int wave)
    {
        height = transform.localScale.y;
        count = 3 + wave / 25;

        int flipFacing = Random.Range(-1, 1);
        facingX = (flipFacing == 0) ? -1 : 1;
        flipFacing = Random.Range(-1, 1);
        facingY = (flipFacing == 0) ? -1 : 1;

        index = 0; 
    }
}
