using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass {

    private float speed, jumpForce, maxSpeed;
    private int health;
    private bool lost = false;

    //Constructor
    public PlayerClass(float speed, float jumpForce, int health) {
        this.speed = speed;
        this.health = health;
        this.jumpForce = jumpForce;
    }

    //Set Player Speed
    public void SetSpeed(float speed) {
        this.speed = speed;
    }
    public float GetSpeed() {
        return this.speed;
    }

    public void SetHealth(int health) {
        this.health = health;
    }

    //Take one damage
    public void TakeDamage() { 
        health--;
    }

    //Get Health
    public int GetHealth() {
        return this.health;
    }

    public void SetJumpForce(float jumpForce) {
        this.jumpForce = jumpForce;
    }

    public float GetJumpForce() {
        return this.jumpForce;
    }

    public void Lost() {
        this.lost = true;
        this.speed = 0;
        this.jumpForce = 0;
    }

    public bool GetLost() {
        return this.lost;
    }

    public float GetMaxSpeed() {
        return this.maxSpeed;
    }

    public void SetMaxSpeed(float val) {
        this.maxSpeed = val;
    }
}
