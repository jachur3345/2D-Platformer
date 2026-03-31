using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxhealth = 100;
    private float health;
    private bool canreceivedamage;
    public float invincibilitytimer = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
    }
    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        Debug.Log(health);
    }
}