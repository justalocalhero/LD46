using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public float tutorialTime = 5;

    private void Update()
    {
        tutorialTime -= Time.deltaTime;

        if (tutorialTime <= 0) gameObject.SetActive(false);
    }
}
