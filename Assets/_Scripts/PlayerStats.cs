using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RPGCharacterAnims;
using EmeraldAI;

public class PlayerStats : EmeraldPlayerBridge
{
    
    public int CurrentHealth; 
    public new int StartHealth = 100;

    public int CurrentStamina ;
    public int StartStamina = 100;

    [Space]
    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    private _CharacterController _characterController;

     public override void Start()
    {

        _characterController = GetComponent<_CharacterController>();

        CurrentHealth = StartHealth;
        CurrentStamina = StartStamina;
    }

    // public void Damage(int DamageAmount, Transform AttackerTransform = null, int RagdollForce = 100, bool CriticalHit = false)
    //{
    //    if (_characterController.isBlocking)
    //    {
    //        Debug.Log("blocking");
    //    }
    //    else
    //    {
    //        CurrentHealth -= DamageAmount;
    //        OnTakeDamage.Invoke();
    //    }
    //
    //
    //    if (CurrentHealth <= 0)
    //    {
    //        PlayerDeath();
    //    }
    //}

    public override void DamageCharacterController(int DamageAmount, Transform Target)
    {
        if(IsBlocking())
        {
            Debug.Log("blocking");
        }
        else
        {
            CurrentHealth -= DamageAmount;
            DamageEvent.Invoke();
        }
       

        if (CurrentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        DeathEvent.Invoke();
    }

    public override bool IsAttacking()
    {
        return _characterController.isAttacking;
    }

    public override bool IsBlocking()
    {
        return _characterController.isBlocking;
    }
}
