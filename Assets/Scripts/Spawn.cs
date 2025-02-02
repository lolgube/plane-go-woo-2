﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    // writen originally by mohammed and updated again by the same guy (whoa)

    // rate of how often enemies spawn
    public float rate;
    public GameObject[] enemies;
    public int waves = 1;
    public Sprite[] asteroidSprites;

    void Start() {
        //invokeRepeating basically starts a desired function after x time, 
        //and then runs that function again every x time
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    // a lot of code in a single line.
    // spawns a random enemy from the array, from the left to the right side of the screen on y level 7, 
    // making sure they're facing the right direction
    // instantiate works by gameobject - position - direction/rotation
    // the for loop decides how many times we're running this code, the higher the waves in the more things it spawns
    
    // new edit; maybe change this line so that we can specify how often we want a specific enemy to spawn, and not just a random one. 
    // like having 2 variants of an enemy (the asteroid for example) just doubles their spawn rate. not intentional and annoying
    // i solved the problem by randomizing their sprite, which doesn't switch the collider but works well enough
    // for nobody to notice. 
    void SpawnEnemy() {  
        for(int i=0; i<waves;i++)
            Instantiate(enemies[(int)Random.Range(0,enemies.Length)], new Vector3(Random.Range(-8f,8f),7,10), Quaternion.identity);
    }
}