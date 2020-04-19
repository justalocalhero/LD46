using UnityEngine;
using System.Collections;

public class AfterImage : MonoBehaviour
{
    public float maxLifetime, colorMax, colorMin;
    private float lifetime;
    public SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        Color color = spriteRenderer.color;
        color.a = colorMax;
        spriteRenderer.color = color;

        lifetime = maxLifetime;
    }

    void FixedUpdate()
    {
        if(lifetime <= 0)
        {
            gameObject.SetActive(false);
        }

        lifetime -= Time.deltaTime;

        float dt = lifetime / maxLifetime;
        float colorDif = colorMax - colorMin;
        Color color = spriteRenderer.color;
        color.a = colorMax - (1 - dt * dt) * colorDif;
        spriteRenderer.color = color;


    }
}
