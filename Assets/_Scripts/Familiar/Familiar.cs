using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    public bool alive;
    public Sprite spookSprite;
    public SpriteRenderer spriteRenderer;
    private bool spooked = false;
    private float spookTimer, spookTimeout;

    public IBehaviour[] behaviours;
    private IBehaviour currentBehaviour;
    [System.NonSerialized]
    public Vector3 bearing;
    public Death death;

    void Start()
    {
        alive = true;
        behaviours = GetComponents<IBehaviour>();
        AI();
    }

    void FixedUpdate()
    {
        if (!alive) return;

        if(spookTimeout > 0) spookTimeout -= Time.fixedDeltaTime;
        if (!spooked) return;
        spookTimer -= Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + bearing, 8 * Time.fixedDeltaTime);
        if (spookTimer <= 0)
        {
            spooked = false;
            AI();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Projectile"))
        {
            death.Die();
        }

        if(col.CompareTag("Shield"))
        {
            if (!spooked && spookTimeout <= 0)
            {
                bearing = transform.position - col.gameObject.transform.position;
                Spook(bearing);
            }
        }
    }

    public void Deactivate()
    {
        if (currentBehaviour != null) currentBehaviour.Deactivate();
    }
    public void AI()
    {
        if (!alive) return;

        currentBehaviour = behaviours[Random.Range(0, behaviours.Length)];
        currentBehaviour.Activate();
    }

    public void Spook(Vector3 bearing)
    {
        this.bearing = bearing;
        SetSprite(spookSprite);

        spooked = true;
        spookTimer = .12f;
        spookTimeout = 1;

        currentBehaviour.Deactivate();
    }

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}

public interface IBehaviour
{
    void Activate();
    void Deactivate();
}
