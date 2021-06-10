using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    public string[] targetName;
    private HP HPTarget;

    public GhostMovement ghost;
    public int damage;

    void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < targetName.Length; i++)
        {
            if (collision.gameObject.tag == targetName[i])
            {
                HPTarget = collision.gameObject.GetComponent<HP>();
                HPTarget.RemoveLife(damage);
            }
        }
        if(collision.gameObject.tag == "pile" && gameObject.tag == "light")
        {
            if (!collision.GetComponent<AudioSource>().isPlaying)
            {
                collision.GetComponent<AudioSource>().Play();
            }        
        }
        if (collision.gameObject.tag == "ghost" && gameObject.tag == "light")
        {
            ghost = collision.gameObject.GetComponent<GhostMovement>();
            ghost.anim.SetBool("isBurning", true);
            if (!ghost.burning.isPlaying)
            {
                ghost.burning.Play();
            }
            ghost.isTargeted = true;
        }else if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerBehavior>().SetIsAttacked(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ghost" && gameObject.tag == "light")
        {
            ghost = collision.gameObject.GetComponent<GhostMovement>();
            ghost.isTargeted = false;
            ghost.anim.SetBool("isBurning", false);
            ghost.burning.Stop();
        }else if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerBehavior>().SetIsAttacked(false);
        }

        if (collision.gameObject.tag == "pile" && gameObject.tag == "light")
        {
            collision.GetComponent<AudioSource>().Stop();
        }
    }
}
