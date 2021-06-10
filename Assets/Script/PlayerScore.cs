using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public PlayerScore[] players;

    private void Start()
    {
        players = FindObjectsOfType<PlayerScore>();
        if(players.Length != 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
