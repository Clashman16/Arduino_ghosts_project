using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject lightOn;
    public GameObject lightOnPain;
    public GameObject lightOff;
    public PlayerBehavior player;
    //energy
    public float energyMax;
    private float currentEnergy;
    
    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = energyMax;
    }

    // Update is called once per frame
    void Update()
    {
        currentEnergy -= Time.deltaTime;
        if(currentEnergy <= 0)
        {
            lightOff.SetActive(true);
            lightOn.SetActive(false);
        }
        else
        {
            lightOff.SetActive(false);
            lightOn.SetActive(true);
            lightOnPain.SetActive(player.GetIsAttacked());
        }
    }

    public void RefillEnergy()
    {
        currentEnergy = energyMax;
    }

    public float GetCurrentEnergy()
    {
        return currentEnergy;
    }
}
