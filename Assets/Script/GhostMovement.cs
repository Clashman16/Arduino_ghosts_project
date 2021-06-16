using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Transform ghost;
    private Rigidbody2D myRigidBody;

    //animator
    public Animator anim;

    //death
    public AudioSource burning;
    public AudioSource death;
    public float timerDead;
    public bool isDead;
    public GhostManager ghostMana;
    public HP hp;

    public bool can_move;
    public bool isTargeted;

    //with target
    private Vector3 movement;
    public GameObject Target;
    public float movespeed;
    public float period;
    public float delay;
    public float f0;
    public float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        ghost = GetComponent<Transform>();
        ghostMana = FindObjectOfType<GhostManager>();
        anim = GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player");
        hp = GetComponent<HP>();

        movespeed = Random.Range(85f, 200f);
        period = Random.Range(750f, 1500f);
        delay = Random.Range(0, 6f);
        f0 = Random.Range(350, 550);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Vector3 direction = Target.transform.position - transform.position;
            time += 0.000005f;
            if (Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)) > 175f)
            {
                direction -= new Vector3(0, f0 * Mathf.Sin(period * time + delay), 0);
                can_move = true;
                anim.SetTrigger("isWalking");
            }
            else
            {
                can_move = false;
                anim.SetTrigger("isAttacking");
            }
            direction.Normalize();
            movement = direction;
        }
        else
        {
            if (timerDead > 0)
            {
                if (!death.isPlaying)
                {
                    death.Play();
                }
                anim.SetTrigger("isDead");
                timerDead -= Time.deltaTime;
            }
            else
            {
                ghostMana.currentGhost -= 1;
                burning.Stop();
                death.Stop();
                Destroy(gameObject);
                ghostMana.countDead += 1;
                ghostMana.haveToChangeRogue = true;
            }
        }

        if(hp.GetCurrentHP() <= 0)
        {
            isDead = true;
        }
    }

    private void FixedUpdate()
    {
        if (can_move && !isTargeted)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        myRigidBody.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }

}
