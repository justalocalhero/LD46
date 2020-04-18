using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMouse : MonoBehaviour
{
    private Camera mainCamera;
    private float timer;
    public float maxTimer;

    public void Start()
    {
        mainCamera = Camera.main;
    }

    public void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if(Input.GetMouseButtonDown(0))
        {
        
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            timer = 0;
        }
        else
        {

        }
    }
}
