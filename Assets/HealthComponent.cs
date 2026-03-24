using System;
using System.Collections;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public float invincibilityTime = 2f;
    private bool canReciveDamage = true;

    private int currentHealth;
    
    public delegate void HealthChangedHandler(int oldHealth, int amountChanged, Vector3 origin);
    public event HealthChangedHandler OnHealthChanged;
    public delegate void HealthInitHandler(int maxHealth, int currentHealth);
    public event HealthInitHandler OnHealthInitialized;

    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthInitialized?.Invoke(currentHealth, maxHealth);
    }
    
    public int ReceiveDamage(int amount, Vector3 origin)
    {
        if (canReciveDamage)
        {
            Debug.Log("Recieved Damage");
            OnHealthChanged?.Invoke(currentHealth, amount, origin);
            canReciveDamage = false;
            StartCoroutine(RunInvincibilityTimer(invincibilityTime, RefreshInvincibility));
            return currentHealth += amount;
        }
        else
        {
            return 0;
        }
    }

    IEnumerator RunInvincibilityTimer(float waitTime, Action callback)
    {
        yield return new WaitForSeconds(waitTime);
        callback.Invoke();
    }

    private void RefreshInvincibility()
    {
        canReciveDamage = true;
        Debug.Log("Reset");
    }
}
