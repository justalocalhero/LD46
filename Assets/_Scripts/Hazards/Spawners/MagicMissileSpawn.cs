using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissileSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public int difficulty { get { return _difficulty; } }

    public ObjectPool dartSpawner;
    public Familiar familiar;

    public void Fire(int wave)
    {
        float height = transform.localScale.y;
        int count = wave;

        int flipFacing = Random.Range(-1, 1);
        int facingX = (flipFacing == 0) ? -1 : 1;
        flipFacing = Random.Range(-1, 1);
        int facingY = (flipFacing == 0) ? -1 : 1;

        for (int i = 0; i < count; i++)
        {
            float dy = Random.Range(-height / 2, height / 2);

            GameObject go = dartSpawner.Get();
            MagicMissile missile = go.GetComponent<MagicMissile>();
            missile.targetTransform = familiar.transform;
            Vector3 position = transform.position;

            position.x = position.x * facingX;
            position.y = position.y * facingY;

            go.transform.position = position;

            go.SetActive(true);
        }
    }
}
