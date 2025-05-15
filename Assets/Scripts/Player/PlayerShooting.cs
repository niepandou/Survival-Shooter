using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    public float timeBetweenBullets;
    public float timeCounterSpeed;
    private float timeCounter;
    private bool couldShoot;
    
    //检测敌人部分
    private Ray shootRay;
    private RaycastHit shootHit;

    //射击枪光在射击间隔时间内可以存在的时间占比
    public float shootLightEffectPercentage;
    [Header("组件")]
    private AudioSource audioGunShot;
    //开枪光
    private Light shootLight;
    //子弹射线
    private LineRenderer shootLine;
    private ParticleSystem shootParticle;
    private Attack attack;
    
    private void Awake()
    {
        audioGunShot = GetComponent<AudioSource>();
        shootLight = GetComponent<Light>();
        shootLine = GetComponent<LineRenderer>();
        shootParticle = GetComponent<ParticleSystem>();
        attack = GetComponent<Attack>();
        
    }

    private void Update()
    {
        if (!PlayerController.IsInputEnabled) return;

        if (Input.GetButton("Fire1"))
        {
            if (couldShoot)
            {
                Shoot();
            }
        }

        if (timeCounter >= timeBetweenBullets * shootLightEffectPercentage)
        {
            ShootFinish();
        }
        
        if(!couldShoot)
            TimeCounter();
        
    }

    

    void Shoot()
    {
        couldShoot = false;
        shootLight.enabled = true;
        
        //播放粒子特效
        shootParticle.Play();
        //播放射击音效
        audioGunShot.Play();
        //检测是否命中敌人

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        
        //子弹射线起点
        shootLine.SetPosition(0,transform.position);
        //子弹射线终点
        if (Physics.Raycast(shootRay, out shootHit, 100, 
                LayerMask.GetMask("Enemy")))
        {
            //检测到,就发射一条枪到敌人的射线
            shootLine.SetPosition(1,shootHit.point);
            //让敌人自行计算伤害
            attack.AttackTarget(shootHit.collider,shootHit.point);
        }
        else
        {
            //未检测到,发射的就是一条无限长的射线
            shootLine.SetPosition(1,transform.position + transform.forward * 100);
        }
        
        shootLine.enabled = true; 

    }

    void ShootFinish()
    {
        shootLight.enabled = false;
        shootLine.enabled = false;
    }
    public void TimeCounter()
    {
        timeCounter +=  timeCounterSpeed * Time.deltaTime;
        if (timeCounter >= timeBetweenBullets)
        {
            couldShoot = true;
            timeCounter = 0;
        }
    }
    
}
