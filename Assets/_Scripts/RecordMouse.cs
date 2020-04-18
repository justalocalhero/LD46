using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMouse : MonoBehaviour
{
    public bool active;

    private Camera mainCamera;
    private float timer;

    public BuildBox buildBox;
    public float maxTimer, minDistance;
    private Vector3 p1, p2;
    private int count;


    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            active = true;
        }

        if (!active) return;

        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if(Input.GetMouseButton(0) && timer <= 0)
        {
            timer += maxTimer;

            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            if (count >= 1 && Vector3.Distance(p1, mousePosition) <= minDistance) return;

            p1 = p2;
            p2 = mousePosition;

            if (++count <= 1) return;

            buildBox.Build(p1, p2);
        }

        if(Input.GetMouseButtonUp(0))
        {
            Clear();
        }
    }
    public void Clear()
    {
        count = 0;
        active = false;
    }
}
