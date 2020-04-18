using UnityEngine;
using System.Collections;

public class Dagger : MonoBehaviour
{
    public int speed;

    [System.NonSerialized]
    public Vector3 target;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Shield"))
        {
            gameObject.SetActive(false);
        }
    }

}
