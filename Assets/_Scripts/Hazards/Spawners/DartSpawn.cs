using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public int difficulty { get { return _difficulty; } }

    public ObjectPool dartSpawner;

    public void Fire(int wave)
    {
        float height = transform.localScale.y;
        int count = wave;

        for (int i = 0; i < count; i++)
        {
            float dy = Random.Range(-height / 2, height / 2);

            int flipFacing = Random.Range(-1, 1);
            int facing = (flipFacing == 0) ? -1 : 1;

            GameObject go = dartSpawner.Get();
            Dart dart = go.GetComponent<Dart>();
            dart.bearing = new Vector3(-facing, 0, 0);
            Vector3 position = transform.position;
            position.x = position.x * facing;
            position.y += dy;
            go.transform.position = position;

            go.SetActive(true);
        }
    }
}
