using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public HazardManager hazardManager;
    public ObjectPool[] objectPools;
    public bool dying;
    public float deathTime;


    public void Die()
    {
        dying = true;
        hazardManager.active = false;
        PlayerPrefs.SetInt("Score", hazardManager.currentWave);

        foreach(ObjectPool pool in objectPools)
        {
            pool.Kill();
        }
    }

    public void Update()
    {
        if (!dying) return;

        deathTime -= Time.deltaTime;

        if(deathTime <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    
}
