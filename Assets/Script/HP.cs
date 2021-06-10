using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int currentHP;
    public int maxHP;

    public float coolDownDamage;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        currentTime = 0f;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
    }

    public void RemoveLife(int HPToRemove)
    {
        if(currentTime <= 0)
        {
            currentHP -= HPToRemove;
            currentTime = coolDownDamage;
        }  
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
