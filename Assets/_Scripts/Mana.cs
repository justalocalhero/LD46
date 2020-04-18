using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float maxMana, currentMana, manaRegen;

    void FixedUpdate()
    {
        currentMana += (manaRegen * Time.deltaTime);
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
    }
}
