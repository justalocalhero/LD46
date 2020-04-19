using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public Transform maskTransform;
    public float maxMana, currentMana, manaRegen;

    void FixedUpdate()
    {
        currentMana += (manaRegen * Time.deltaTime);
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);

        Vector3 pos = maskTransform.localPosition;
        pos.y = (currentMana / maxMana);
        maskTransform.localPosition = pos;
    }
}
