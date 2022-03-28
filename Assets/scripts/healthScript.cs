using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour {

    public int health;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;
    }
}
