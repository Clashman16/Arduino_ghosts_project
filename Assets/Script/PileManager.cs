using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileManager : MonoBehaviour
{
    private bool isThereAPile;
    public LightManager lightMana;
    public GameObject pile;

    // Start is called before the first frame update
    void Start()
    {
        isThereAPile = false;
        lightMana = FindObjectOfType<LightManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isThereAPile && lightMana.GetCurrentEnergy() < lightMana.energyMax/2)
        {
            Instantiate(pile, new Vector3(Random.Range(50, 1870), Random.Range(50, 975), 0), transform.rotation);
            isThereAPile = true;
        }
    }

    public void PileDestroyed()
    {
        GetComponent<AudioSource>().Play();
        isThereAPile = false;
    }
}
