using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// made by Thijs Dreef
public class PlayerHit : MonoBehaviour
{
    [SerializeField] private HealthManagement _healthManagement;
    [SerializeField] private String _attack;
    [SerializeField] private String _fall;

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == _attack)
        {
            _healthManagement.TakeDamage(1);
        }
        if (other.gameObject.tag == _fall)
        {
            _healthManagement.TakeDamage(3);
        }
    }
}
