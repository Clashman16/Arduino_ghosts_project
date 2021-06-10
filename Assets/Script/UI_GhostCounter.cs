using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GhostCounter : MonoBehaviour
{
    public GhostManager ghostMana;
    private UnityEngine.UI.Text ghostCounterText;

    void Start()
    {
        ghostCounterText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ghostCounterText.text = ghostMana.currentGhost.ToString();
    }
}
