using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Familiar familiar;
    public ObjectPool afterImagePool;
    private bool blinking;
    public float blinkSpriteTime;
    private float currentBlinkSpriteTimer;
    public Sprite blinkSprite;
    public Sprite[] idleSprites;
    public float idleTime;
    private float idleTimer;
    private int idleIndex;

    public void Update()
    {
        if(blinking)
        {
            currentBlinkSpriteTimer -= Time.deltaTime;

            if (currentBlinkSpriteTimer <= 0)
            {
                idleTimer = idleTime;
                idleIndex = 0;
                blinking = false;
            }
        }

        else
        {
            idleTimer -= Time.deltaTime;
            if(idleTimer <= 0)
            {
                idleTimer = idleTime;
                SetSprite(idleSprites[idleIndex++ % idleSprites.Length]);
            }
        }
    }
    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public void Blink(Vector3 p1, Vector3 p2)
    {

        Vector3 half = (p1 + p2) / 2f;
        Vector3 bearing = familiar.transform.position - half;
        bearing.Normalize();

        Vector3 halfAgain = half + 2 * bearing;

        if (Vector3.Distance(halfAgain, transform.position) < .25f) return;

        Blink(halfAgain);
    }

    void Scatter(Vector3 from)
    {
        Vector3 bearing = transform.position - from;
        bearing.Normalize();

        Blink(transform.position + bearing);

    }

    private void Blink(Vector3 pos)
    {
        SetSprite(blinkSprite);
        blinking = true;
        currentBlinkSpriteTimer = blinkSpriteTime;

        AfterImage(transform.position);
        transform.position = pos;
    }

    void AfterImage(Vector3 pos)
    {
        GameObject go = afterImagePool.Get();
        go.transform.position = pos;
        go.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Projectile"))
        {
            Scatter(col.transform.position);
        }
    }

}
