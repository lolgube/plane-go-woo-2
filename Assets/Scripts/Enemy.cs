﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // originally written by mohammed with lots of people jumping in and adding various lines.
    // just look at the old project to compare what's been added. 
    Rigidbody2D rb;
    // first two are self explanatory, latter 2 are health drops and power-up-drops 
    public GameObject bullet,explosion,battery,pscore;
    public Color bulletColor;
    // shooting position
    public GameObject c;

    public float xSpeed, ySpeed;
    public bool canShoot;
    public float fireRate, health;
    // how much score our enemies are worth
    public int score;
    public BossSpawn spawn;

    // gets our rb
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        Destroy(gameObject,32);

        // if we can't shoot, piss off
        if(!canShoot) return;{
            //finds our shooting location
            c = transform.Find("C").gameObject;

            // randomizes the firerate to either shoot twice as slow or half as fast
            // i realize now that "half as slow" and "half as fast" don't make much sense.
            // this is confusing. 
            // what would you even go about calling /-2..
            // negative half as fast?
            fireRate=fireRate+(Random.Range(fireRate/-2,fireRate/2));
            // will repeat the function called Shoot for firerate seconds every firerate
            InvokeRepeating("Shoot",fireRate,fireRate);
            }
    }

    void Update() {
        // y speed needs to be negative (since it's going down)
        rb.velocity = new Vector2(xSpeed,ySpeed*-1);
    }

    // if collission with player
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Player"){
        
            // enemy collides with player ship, get player collider, 
            // ...get player gameobject, get spaceship script, take damage.
            col.gameObject.GetComponent<SpaceShip>().Damage();
            // also kill the enemy (they suck)
            Die();
        }
        
    }
    //If the enemies collides with the bosses laser they die without dropping items or giving points - Elio
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Die() {
        if((int)Random.Range(0,4)==0) {
            Instantiate(battery,transform.position,Quaternion.identity);
            // one in 7  chance to spawn battery
        }
        //If player doesnt have max power the enemies will drop power thingies - Elio
        if(SpaceShip.PScore < 100) {
            if((int)Random.Range(0,2)==0) {
            // one in 4 (maybe change?) chance to spawn p-score (just the tiny one)
            Instantiate(pscore,transform.position,Quaternion.identity);
            }
        }
        
        //transform.localScale += scaleChange;

        // plays our explosion particle effect
        Instantiate(explosion,transform.position,Quaternion.identity);
            // die
            Destroy(gameObject);
            // adds score onto our score variable using playerprefs
            // playerprefs is handy cause it saves it onto the computer and not just the current session
            // actually this is dumb and useless, but it works.
            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+score);
            BossSpawn.barScore += score;//ökar bossspawnslidern med lika mycket som playerscore.-Alfred
            // maybe play a sound?
    }

    // if they take damage, reduce health, if health at 0, die function. 
    public void Damage(){
        health--;
        if (health == 0){
            Die();
        }
    }

    // spawns a bullet at our c location and flips the direction from the bullet script. 
    void Shoot(){
        GameObject temp = (GameObject) Instantiate(bullet,c.transform.position,Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        // if we want to fuck with the size of the bullet, refer to this line
        //temp.transform.localScale = new Vector3(whatever.x, whatever.y, whatever.z);

        // lets us change our instantiated bullets color
        // fyi you need to change the alpha to be able to see the bullets,  
        // unity ain't smart enough to do that on its own.
        temp.GetComponent<Bullet>().ChangeColor(bulletColor);
    }

}
