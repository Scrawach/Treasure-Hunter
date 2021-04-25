using System;
using System.Collections;
using Common;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class SelfDamage : MonoBehaviour
{
    [SerializeField] 
    private int _damage;

    [SerializeField] 
    private float _afterTime;

    private void Awake()
    {
        StartCoroutine(SelfDamaging());
    }

    private IEnumerator SelfDamaging()
    {
        yield return new WaitForSeconds(_afterTime);
        GetComponent<Health>().TakeDamage(_damage);
    }
}