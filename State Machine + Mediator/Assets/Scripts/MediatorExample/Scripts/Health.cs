using System;
using System.Collections;
using UnityEngine;

namespace MediatorExample.Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int fullHealth = 100;
        [SerializeField] private int drainPerSecond = 2;
        [SerializeField] private float currentHealth;
        public event Action Death;

        private void Start()
        {
            ResetHealth();
        }

        private void Update()
        {
            Debug.Log(currentHealth);
            if (currentHealth <=0 ) OnDead();
        }

        public void ResetHealth()
        {
            currentHealth = fullHealth;
            StartCoroutine(DrainHealth());
        }

        public float GetHealth()
        {
            return currentHealth;
        }

        private IEnumerator DrainHealth()
        {
            while (currentHealth > 0)
            {
                currentHealth -= drainPerSecond;
                yield return new WaitForSeconds(1);
            }
            
        }

        private void OnDead()
        {
            Death?.Invoke();
        }
    }
}