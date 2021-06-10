using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GhostAttackImageManager : MonoBehaviour
{
    public PlayerBehavior player;
    public Sprite[] ghost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetIsAttacked())
        {
            GetComponent<UnityEngine.UI.Image>().sprite = ghost[1];
        }
        else
        {
            GetComponent<UnityEngine.UI.Image>().sprite = ghost[0];
        }
    }
}
