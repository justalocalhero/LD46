using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public int difficulty { get { return _difficulty; } }

    public ObjectPool arrowSpawner;

    public void Fire(int wave)
    {
        float width = transform.localScale.x;
        int count = wave;
        float dx = width / count;

        for (int i = 0; i < count; i++)
        {
            GameObject go = arrowSpawner.Get();
            Arrow arrow = go.GetComponent<Arrow>();
            arrow.bearing = Vector3.down;
            Vector3 position = transform.position;
            position.x += ((i - (count - 1) / 2.0f) * dx);
            go.transform.position = position;

            go.SetActive(true);
        }
    }
}
