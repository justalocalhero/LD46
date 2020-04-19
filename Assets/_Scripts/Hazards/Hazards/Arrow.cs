using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public float ds;
    public float terminalSpeed;
    private float currentSpeed, lifetime;


    [System.NonSerialized]
    public Vector3 bearing;

    void OnEnable()
    {
        lifetime = 5;
        currentSpeed = speed;
    }

    void FixedUpdate()
    {
        lifetime -= Time.fixedDeltaTime;

        if(lifetime <= 0)
        {
            gameObject.SetActive(false);
        }

        if(currentSpeed > terminalSpeed)
        {
            currentSpeed += (ds * Time.fixedDeltaTime);
            currentSpeed = Mathf.Clamp(currentSpeed, terminalSpeed, speed);

        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + bearing, currentSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Shield"))
        {
            gameObject.SetActive(false);
        }
    }
}
