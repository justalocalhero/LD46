using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public int speed;
    public float lifetime;

    [System.NonSerialized]
    public Vector3 bearing;

    [System.NonSerialized]
    public ObjectPool explosionPool;

    void OnEnable()
    {
        lifetime = .5f;
        transform.localScale = new Vector3(.1f, .1f, 1);
    }

    void FixedUpdate()
    {
        if (lifetime <= 0) gameObject.SetActive(false);

        lifetime -= Time.deltaTime;
        transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(3, 3, 1), speed * Time.deltaTime);
    }
}
