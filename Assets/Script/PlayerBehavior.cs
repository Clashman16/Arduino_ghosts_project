using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private HP life;
    private bool isAttacked;
    private AudioSource shout;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<HP>();
        shout = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life.GetCurrentHP() < 0)
        {
            anim.SetTrigger("death");
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f)
            {
                SceneManager.LoadScene(2);
            }   
        }

        if (isAttacked)
        {
            anim.SetBool("fear", true);
        }
        else
        {
            anim.SetBool("fear", false);
        }
    }

    public HP GetLife()
    {
        return life;
    }

    public bool GetIsAttacked()
    {
        return isAttacked;
    }

    public void SetIsAttacked(bool status)
    {
        isAttacked = status;
        if (status && !shout.isPlaying)
        {
            shout.Play();
            return;
        }
    }
}
