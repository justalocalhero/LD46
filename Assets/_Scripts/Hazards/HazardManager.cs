using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public bool active;
    public int maxWave;
    public int currentWave = 1;
    public IHazard[] hazards;
    public List<IHazard> activeHazards = new List<IHazard>();
    public float timeout;
    public int queue;
    public void Start()
    {
        hazards = GetComponentsInChildren<IHazard>();
        UpdateActiveHazards();
        active = true;
    }

    public void Update()
    {
        if (!active) return;

        if(timeout < 0)
        {
            Fire();

            if (queue <= 0)
            {
                currentWave++;
                timeout += 4f;
                queue = 1;
                if (currentWave > 10) queue++;
                currentWave += (currentWave / 50);
            }
            else
            {
                queue--;
                timeout += 1f;
            }
        }
        timeout -= Time.deltaTime;
    }

    public void Fire()
    {
        currentWave = Mathf.Clamp(currentWave, 0, maxWave);
        UpdateActiveHazards();

        activeHazards[Random.Range(0, activeHazards.Count)].Fire(currentWave);

    }

    public void UpdateActiveHazards()
    {
        activeHazards.Clear();

        foreach(IHazard hazard in hazards)
        {
            if(hazard.difficulty <= currentWave)
            {
                activeHazards.Add(hazard);
            }
        }
    }
}

public interface IHazard
{
    int difficulty { get; }
    void Fire(int wave);

}
