using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] private Image _damageFilter;
    [SerializeField] private Image _deathFilter;
    [SerializeField] private Text _restartText;
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

	// Use this for initialization
	void Start ()
	{
	    _restartText.gameObject.SetActive(false);
	    _currentHealth = _maxHealth;
	}

    void Update()
    {
        if (_currentHealth > 0) return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
    }
    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        var temp = _damageFilter.color;
        temp.a = (float)( 1 - 0.34 * _currentHealth);
        _damageFilter.color = temp;
        if (_currentHealth <= 0)
        {
            Killed();
        }
    }

    private void Killed()
    {
        var temp = _deathFilter.color;
        temp.a = 1;
        _deathFilter.color = temp;
        _restartText.gameObject.SetActive(true);
    }
}
