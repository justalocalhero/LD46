using UnityEngine;

public class Dart : MonoBehaviour
{
    public int speed;

    [System.NonSerialized]
    public Vector3 bearing;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + bearing, speed * Time.fixedDeltaTime);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Shield"))
        {
            gameObject.SetActive(false);
        }
    }
}

