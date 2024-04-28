using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] int damage = 1;
    public int GetDamage() => damage;
    public void Hit() => Destroy(gameObject);
}
