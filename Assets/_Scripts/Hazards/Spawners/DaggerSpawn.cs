using UnityEngine;

public class DaggerSpawn : MonoBehaviour, IHazard
{
    public int _difficulty;
    public int difficulty { get { return _difficulty; } }

    public ObjectPool daggerSpawner;
    public Familiar familiar;

    private float currentTimer;
    public float fireTime;
    private int index;
    private int count;

    private bool active;

    public void Start()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }


    public void Update()
    {
        if (!active) return;
        if (index >= count) return;
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            index++;
            currentTimer += fireTime;
            Fire();
        }
    }

    public void Fire()
    {
        GameObject go = daggerSpawner.Get();
        Dagger dagger = go.GetComponent<Dagger>();
        go.transform.position = transform.position;
        dagger.bearing = familiar.transform.position - transform.position;

        go.SetActive(true);

    }

    public void Fire(int wave)
    {
        count = 1 + wave / 50;

        index = 0;
    }
}