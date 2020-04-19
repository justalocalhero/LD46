using UnityEngine;
using System.Collections;

public class Lick : MonoBehaviour, IBehaviour
{
    public float lickTime;
    private float lickTimer;
    public Sprite[] lickSprites;
    private bool active;
    public int animationsPerCycle;
    private Familiar familiar;

    public void Start()
    {
        familiar = GetComponent<Familiar>();
    }

    public void Activate()
    {
        lickTimer = lickTime;
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    public void Update()
    {
        if (!active) return;

        lickTimer -= Time.deltaTime;

        float ratio = Mathf.Clamp(lickTimer / lickTime, 0, 1);
        int frame = Mathf.FloorToInt(animationsPerCycle * lickSprites.Length * ratio) % lickSprites.Length;
        Debug.Log(frame);
        familiar.SetSprite(lickSprites[frame]);

        if (lickTimer <= 0)
        {
            active = false;
            familiar.AI();
        }
    }
}
