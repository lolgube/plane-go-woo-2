﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explosion,battery;

    // sets our firerate and health
<<<<<<< Updated upstream
    public float bossHealth;
    // how much score our enemies are worth
    public int bossScore;
=======
    public float health;
    // how much score our enemies are worth
    public int score;
>>>>>>> Stashed changes



    // gets our rb
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {

    }

    void Update() {

    }

    // if collission with player
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Player"){

            // enemy collides with player ship, get player collider, 
            // ...get player gameobject, get spaceship script, take damage.
            col.gameObject.GetComponent<SpaceShip>().Damage();
        }
    }
    
    void BossDie(){
     
        //Spawns battery when boss dies
        Instantiate(battery,transform.position,Quaternion.identity);
            

        // plays our explosion particle effect
        Instantiate(explosion,transform.position,Quaternion.identity);
            // die
            //Destroy(gameObject);
            // adds score onto our score variable using playerprefs
            // playerprefs is handy cause it saves it onto the computer and not just the current session
            // actually this is dumb and useless, but it works.
<<<<<<< Updated upstream
            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+bossScore);
=======
            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+score);
>>>>>>> Stashed changes

            // maybe play a sound?
    }

    // if they take damage, reduce health, if health at 0, die function. 
    public void Damage(){
<<<<<<< Updated upstream
        bossHealth--;
        if(bossHealth == 0){
=======
        health--;
        if(health == 0){
>>>>>>> Stashed changes
            BossDie();
        }
    }
}
