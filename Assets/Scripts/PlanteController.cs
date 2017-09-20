using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine;

public class PlanteController : MonoBehaviour {

    public x360_Gamepad gamepad;
    private GamepadManager manager;

    public int playerIndex;

    public Animator anim;

    public float speed;
    public float turnSpeed;

    public Rigidbody rb;

    public ParticleSystem dust;

    float x;
    float y;

    bool attacking;

    float cooldown;

    Vector3 movement;
    Vector3 direction;

    public float influence = 1;

    void Start () 
	{
        manager = GamepadManager.Instance;
        gamepad = manager.GetGamepad(playerIndex);
        dust.Stop();
    }
	
	void Update () 
	{
        CheckInputs();

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                cooldown = 0;
                attacking = false;
            }
        }

	}

    void CheckInputs()
    {
        x = gamepad.GetStick_L().X;
        y = gamepad.GetStick_L().Y;

        movement = new Vector3(x, 0, y);

        if (x != 0 || y != 0)
        {
            if(anim.GetBool("Walk") ==false)
            {
                anim.SetBool("Walk",true);
                dust.Play();
            }
            Move();

            Rotate();
        }
        else
        {
            if (anim.GetBool("Walk"))
            {
                dust.Stop();
                anim.SetBool("Walk", false);
            }
            if(rb.velocity.magnitude>.5f)
            {
                rb.velocity /= 2;
            }
        }

        if(gamepad.GetButtonDown("A") && !attacking)
        {
            Attack();
        }
    }

    void Move()
    {
        rb.velocity = Vector3.Lerp(rb.velocity, movement * speed, influence);
    }

    void Rotate()
    {
        //ROTATION DE VROUM VROUM   

        direction = new Vector3(0, Mathf.Atan2(y, -x) * 180 / Mathf.PI-90, 0);

        float step = turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, direction.y, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, turnRotation, step);
    }

    void Attack()
    {
        attacking = true;
        cooldown += 1;
        anim.SetTrigger("Attack");

        //CODER ATTAQUE

    }

    
}
