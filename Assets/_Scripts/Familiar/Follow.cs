using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Follow : MonoBehaviour, IBehaviour
{
    private bool active;
    private Vector3 currentTarget;
    public float scatteringRadius, speed, maxMoveTime, maxWaitTime;
    public int maxJumps;
    private int jumpsRemaining;
    private float currentTimer;
    public PounceState currentState;
    public Sprite waitSprite;
    public Sprite pounceSprite;
    public Wizard wizard;

    private Familiar familiar;

    public void Start()
    {
        familiar = GetComponent<Familiar>();
    }

    public void Activate()
    {
        active = true;
        currentTimer = 0;
        currentState = PounceState.wait;
        jumpsRemaining = maxJumps;
    }

    public void Deactivate()
    {
        active = false;
    }

    void FixedUpdate()
    {
        if (!active) return;

        switch (currentState)
        {
            case PounceState.calculate:
                Calculate();
                break;
            case PounceState.wait:
                Wait();
                break;
            case PounceState.move:
                Move();
                break;
            case PounceState.finished:
                Finish();
                break;
            default:
                break;
        }
    }

    void Calculate()
    {
        Vector3 finalTarget = wizard.transform.position;
        finalTarget.y -= .5f;

        Vector3 direction = (finalTarget - transform.position);

        Vector3 scattering = Quaternion.Euler(0f, 0f, Random.Range(0, 360f)) * Vector2.right * scatteringRadius;

        currentTarget = direction + scattering;

        Vector3 localScale = transform.localScale;
        localScale.x = (currentTarget.x > transform.position.x) ? .5f : -.5f;
        transform.localScale = localScale;

        currentTimer += maxMoveTime;
        jumpsRemaining--;
        currentState = PounceState.move;
    }

    void Wait()
    {
        familiar.SetSprite(waitSprite);

        if (jumpsRemaining <= 0)
        {
            currentState = PounceState.finished;
            return;
        }

        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            currentState = PounceState.calculate;
        };
    }

    void Move()
    {
        familiar.SetSprite(pounceSprite);

        currentTimer -= Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime * speed);

        if (currentTimer <= 0)
        {
            currentTimer += Random.Range(.5f * maxWaitTime, maxWaitTime);
            currentState = PounceState.wait;
        };
    }

    void Finish()
    {
        active = false;
        familiar.AI();
    }

    public enum PounceState
    {
        calculate,
        wait,
        move,
        finished
    }

}
