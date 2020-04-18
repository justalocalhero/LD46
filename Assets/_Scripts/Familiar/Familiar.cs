using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    public Pounce pounce;

    void Start()
    {
        AI();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Projectile"))
        {
            gameObject.SetActive(false);
        }
    }

    public void AI()
    {
        pounce.Activate();
    }
}
