using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public int maxWave;
    public int currentWave = 1;
    public IHazard[] hazards;
    public List<IHazard> activeHazards = new List<IHazard>();

    public void Start()
    {
        hazards = GetComponentsInChildren<IHazard>();
        UpdateActiveHazards();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Fire();
        }
    }

    public void Fire()
    {
        currentWave++;
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
