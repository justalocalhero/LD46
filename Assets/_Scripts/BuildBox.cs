using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBox : MonoBehaviour
{
    public ObjectPool pool;
    public Mana mana;
    public RecordMouse recordMouse;

    public float distanceFlat, distanceScale, maxHeight, minHeight, spendPercentage;
    public void Build(Vector3 p1, Vector3 p2)
    {
        if (mana.currentMana < minHeight)
        {
            recordMouse.Clear();
            return;
        }

        float height = Mathf.Clamp(spendPercentage * mana.currentMana, minHeight, maxHeight);
        mana.currentMana -= height;

        GameObject toBuild = pool.Get();
        
        Vector3 centerPos = (p1 + p2) / 2f;
        toBuild.transform.position = centerPos;
        Vector3 direction = p2 - p1;
        direction = Vector3.Normalize(direction);
        toBuild.transform.right = direction;
        Vector3 scale = new Vector3(1, 1, 1);
        float width = (Vector3.Distance(p1, p2) * (1 + distanceScale) + distanceFlat);
        width = Mathf.Clamp(width, height, width);
        scale.x = width;
        scale.y = height;
        toBuild.transform.localScale = scale;

        toBuild.SetActive(true);
    }
}
