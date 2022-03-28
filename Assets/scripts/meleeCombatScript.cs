using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeCombatScript : MonoBehaviour {

    float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform overlapCirclePos;
    public float overlapCircleRadius;
    public LayerMask whatIsEnemies;

    public Animator anim;

	void Update () {
		if(timeBetweenAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                timeBetweenAttack = startTimeBetweenAttack;
                anim.SetBool("isAttacking", true);

                Collider2D[] meleeAttack = Physics2D.OverlapCircleAll(overlapCirclePos.position, overlapCircleRadius, whatIsEnemies);

                for (int i = 0; i < meleeAttack.Length; i++)
                {
                    meleeAttack[i].GetComponent<healthScript>().DealDamage(1);
                }
                
            }
        }
        else
        {
            anim.SetBool("isAttacking", false);
            timeBetweenAttack -= 1;
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(overlapCirclePos.position, overlapCircleRadius);
    }
}
