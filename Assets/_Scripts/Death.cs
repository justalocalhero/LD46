using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Wizard wizard;
    public Familiar familiar;
    public HazardManager hazardManager;
    public ObjectPool[] objectPools;
    public bool dying;
    public float familiarDeathStart, familiarDeathStop, wizardDeathStart, wizardDeathStop, transitionTime;
    private float currentTime;
    public Sprite[] familiarDeathSprites;
    public Sprite[] wizardDeathSprites;


    public void Die()
    {
        foreach (ObjectPool pool in objectPools)
        {
            pool.Kill();
        }

        wizard.Blink(familiar.transform.position + new Vector3(1, 1, 0));
        familiar.Deactivate();
        familiar.alive = false;
        wizard.alive = false;
        dying = true;
        hazardManager.Deactivate();
        PlayerPrefs.SetInt("Score", hazardManager.currentWave);
    }

    public void Update()
    {
        if (!dying) return;

        if(currentTime >= familiarDeathStart && currentTime <= familiarDeathStop)
        {
            float ratio = (currentTime - familiarDeathStart) / (familiarDeathStop - familiarDeathStart);

            int sprites = familiarDeathSprites.Length;

            int frame = Mathf.FloorToInt(sprites * ratio) % sprites;

            familiar.SetSprite(familiarDeathSprites[frame]);
             
        }

        if (currentTime >= wizardDeathStart && currentTime <= wizardDeathStop)
        {
            float ratio = (currentTime - wizardDeathStart) / (wizardDeathStop - wizardDeathStart);

            int sprites = wizardDeathSprites.Length;

            int frame = Mathf.FloorToInt(sprites * ratio) % sprites;

            wizard.SetSprite(wizardDeathSprites[frame]);

        }

        if(currentTime > transitionTime)
        {
            SceneManager.LoadScene("End");
        }

        if(currentTime > familiarDeathStop)
        {
            familiar.gameObject.SetActive(false);
        }

        currentTime += Time.deltaTime;
    }

    
}
