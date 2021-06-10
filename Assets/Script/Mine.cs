using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private HP hp;
    private bool isActive;
    public GameObject aLight;
    private int currentLifetime;
    public int maxLifetime;

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            SetLifeTime();
        }
        
        if(hp.currentHP < 0)
        {
            ActivateLight();
        }
    }

    public void SetLifeTime()
    {
        currentLifetime -= 1;
        if (currentLifetime < 0)
        {
            isActive = false;
            aLight.SetActive(false);
        }
    }

    public void ActivateLight()
    {
        isActive = true;
        aLight.SetActive(true);
        currentLifetime = maxLifetime;
        hp.currentHP = hp.maxHP;
    }
}
