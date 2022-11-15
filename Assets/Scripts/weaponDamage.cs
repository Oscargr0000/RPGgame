using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponDamage : MonoBehaviour
{

    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

        }
    }
}
