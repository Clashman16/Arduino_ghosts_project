using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StartGameButton : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    private PlayerScore player;
    public bool onCollision = false;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (onCollision)
        {
            timer -= 0.1f;
            if(timer < 0)
            {
                SceneManager.LoadScene(1);
            }
        }
        slider.value = slider.maxValue - timer;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        onCollision = true;
        if (collision.gameObject.tag == "button")
        {
            onCollision = true;
            GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "button")
        {
            onCollision = false;
            timer = slider.maxValue;
        }
    }
}
