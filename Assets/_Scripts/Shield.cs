using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float lifetime;
    private float maxLifetime = 1.25f;
    void OnEnable()
    {
        lifetime = maxLifetime;
    }

    void FixedUpdate()
    {
        if (lifetime <= 0) gameObject.SetActive(false);
        lifetime -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Projectile"))
        {
            if(transform.localScale.y <= .1f )
            {
                gameObject.SetActive(false);
            }
            else
            {
                Vector3 localScale = transform.localScale;
                localScale.y = (transform.localScale.y - .05f);
                transform.localScale = localScale;

            }
        }
    }
}
