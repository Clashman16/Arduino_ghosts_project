using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : MonoBehaviour
{
    public HP health;
    public LightManager light;
    private PileManager manager;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HP>();
        light = FindObjectOfType<LightManager>();
        manager = FindObjectOfType<PileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.GetCurrentHP()< 0)
        {
            light.RefillEnergy();
            manager.PileDestroyed();
            Destroy(gameObject);
        }
    }
}
