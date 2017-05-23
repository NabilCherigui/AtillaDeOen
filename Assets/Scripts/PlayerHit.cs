using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
// made by Thijs Dreef
public class PlayerHit : MonoBehaviour
{
	[SerializeField] KeyManager key;
    [SerializeField] private HealthManagement _healthManagement;
    [SerializeField] private String _attack;
    [SerializeField] private String _fall;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _attack)
        {
            _healthManagement.TakeDamage(1);
            other.tag = "Untagged";
        }
        if (other.gameObject.tag == _fall)
        {
            _healthManagement.TakeDamage(3);
        }
    }
}
