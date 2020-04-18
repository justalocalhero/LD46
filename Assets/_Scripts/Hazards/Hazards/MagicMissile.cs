using UnityEngine;
using System.Collections;

public class MagicMissile : MonoBehaviour
{
    [System.NonSerialized]
    public Transform targetTransform;
    public int speed;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Shield"))
        {
            gameObject.SetActive(false);
        }
    }
}
