using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
    public int speed;

    [System.NonSerialized]
    public Vector3 bearing;

    [System.NonSerialized]
    public ObjectPool explosionPool;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + bearing, speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Shield"))
        {
            GameObject go = explosionPool.Get();
            go.transform.position = transform.position;

            go.SetActive(true);        
            gameObject.SetActive(false);
        }
    }
}
