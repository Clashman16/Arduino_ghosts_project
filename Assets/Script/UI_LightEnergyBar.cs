using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LightEnergyBar : MonoBehaviour
{
    public LightManager light;
    private UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = light.energyMax;
        slider.value = light.GetCurrentEnergy();
    }
}
