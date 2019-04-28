using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//Variables
	public float maxHealth;
	public float health;
	public float movementSpeed;
	[SerializeField] private Animation eAnim;

	private GameObject player;

	private bool triggeringPlayer;
	public bool aggro;
    public bool dead;
    public int deadcounter;

	public float attackTimer;
	private float _attackTimer;
	private bool attacked;

	public float maxDamage;
	public float minDamage;
	public float damage;

	//Functions

	void Start(){
		player = GameObject.FindWithTag ("Player");
		_attackTimer = attackTimer;
		health = maxHealth;
        dead = false;
        deadcounter = 0;
	}

	void Update(){
        
		if (health <= 0) {
            dead = true;
			Death ();
		}
        if (!dead)
        {
            if (aggro)
            {
                FollowPlayer();
            }
            if (!aggro)
                eAnim.CrossFade("E_Idle");
        }
	}
	/*
	public void Idle(){
		eAnim.CrossFade ("E_Idle");
	}
	*/
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			triggeringPlayer = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			triggeringPlayer = false;
		}
	}


	public void Attack(){
        if (!dead)
        {
            if (!attacked)
            {
                damage = Random.Range(minDamage, maxDamage);
                player.GetComponent<Player>().health -= damage;
                attacked = true;
                print("Enemy attacked player");
            } //else
              //eAnim.CrossFade ("E_battle_idle");
            eAnim.CrossFade("E_Attack");
        }
	}


	public void FollowPlayer(){
        if (!dead)
        {
            if (!triggeringPlayer)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed);
            }

            if (_attackTimer <= 0)
            {
                attacked = false;
                _attackTimer = attackTimer;
            }

            if (attacked)
                _attackTimer -= 1 * Time.deltaTime;
            Attack();
        }
	}

    public void Dead()
    {
        eAnim.CrossFade("E_Dead");
    }

	public void Death(){
        if (deadcounter == 1)
        {
            Dead();
        }
        else if (deadcounter == 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            eAnim.CrossFade("E_Death_anim");
            eAnim.CrossFadeQueued("E_Dead");
            transform.gameObject.tag = "Dead";
            deadcounter++;
        }
    }

}
