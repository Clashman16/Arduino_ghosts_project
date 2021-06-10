using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FearMeterSlider : MonoBehaviour
{
    private PlayerBehavior player;
    private UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerBehavior>();
            slider.maxValue = player.GetLife().maxHP;
        }
        slider.value = player.GetLife().maxHP - player.GetLife().currentHP;
    }
}
