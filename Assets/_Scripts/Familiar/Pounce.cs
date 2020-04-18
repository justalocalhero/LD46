using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pounce : MonoBehaviour
{
    public Familiar familiar;
    private bool active;
    private Vector3 finalTarget;
    private Vector3 currentTarget;
    public float finalRadius, scatteringRadius, speed, maxMoveTime, maxWaitTime;
    public int maxJumps;
    private int jumpsRemaining;
    private float currentTimer;
    public PounceState currentState;

    public void Activate()
    {
        active = true;
        currentState = PounceState.wait;
        finalTarget = Quaternion.Euler(0f, 0f, Random.Range(0, 360f)) * (Vector2.right * finalRadius);
        jumpsRemaining = maxJumps;
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
        Vector3 direction = (finalTarget - transform.position);
        direction.Normalize();
        direction = direction * speed * maxMoveTime;

        Vector3 scattering = Quaternion.Euler(0f, 0f, Random.Range(0, 360f)) * (Vector2.right * scatteringRadius);

        currentTarget = direction + scattering;

        currentTimer += maxMoveTime;
        jumpsRemaining--;
        currentState = PounceState.move;
    }

    void Wait()
    {
        if (jumpsRemaining <= 0)
        {
            currentState = PounceState.finished;
            return;
        }

        currentTimer -= Time.deltaTime;
        if(currentTimer <= 0)
        {
            currentState = PounceState.calculate;
        };
    }
    
    void Move()
    {
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
