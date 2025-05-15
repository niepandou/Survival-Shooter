using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator),typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [Header("组件")]
    private Animator anim;
    private NavMeshAgent nav;
    private Rigidbody rb;
    private AudioSource audioSource;
    public CapsuleCollider colider;
    public SphereCollider triggerColider;
    private Attack attack;
    
    public AudioClip hurtSFX;
    public AudioClip deadSFX;
    public bool isSinking;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        colider = GetComponent<CapsuleCollider>();
        triggerColider = GetComponent<SphereCollider>();
        nav = GetComponent<NavMeshAgent>();
        attack = GetComponent<Attack>();
        
        audioSource.clip = hurtSFX;
    }
    
    public void Die()
    {
        audioSource.clip = deadSFX;
        audioSource.Play();
        triggerColider.enabled = false; 
        
        //取消ai跟随
        nav.enabled = false;
        //取消物理影响
        rb.isKinematic = true;
        
        gameObject.layer = LayerMask.NameToLayer("Default");
        anim.SetTrigger("dead");
    }

    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }

    public void StartSinking()
    {
        isSinking = true;
        colider.enabled = false;    
    }
}
