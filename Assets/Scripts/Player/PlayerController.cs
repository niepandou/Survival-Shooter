using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static bool IsInputEnabled = true;

    public float normalSpeed;
    private Rigidbody rb;
    public AudioClip hurtSFX;
    public AudioClip deathSFX;
    private AudioSource audioSource;
    public bool isDead;
    
    [Header("状态")]
    public bool isWalk;

    private void Awake()
    {
        // 设置目标帧率为无限制（-1 表示不限制）
        Application.targetFrameRate = 120;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hurtSFX;
    }

    private void FixedUpdate()
    {
        if (!IsInputEnabled) return;
        
        Move();
        Turning();
    }

    //玩家朝向旋转
    private void Turning()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        int groundLayer = LayerMask.GetMask("Ground");
        RaycastHit groundHit;
        bool isTouchGround = Physics.Raycast(cameraRay, out groundHit, 100, groundLayer);
        if (isTouchGround)
        {
            Vector3 faceDir = groundHit.point - transform.position;
            faceDir.y = 0;
        
            Quaternion quaternion = Quaternion.LookRotation(faceDir);
            rb.MoveRotation(quaternion);
        }
    }

    //玩家移动
    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //是否正在行走的判定
        isWalk = horizontalInput != 0 || verticalInput != 0;
        
        //计算前进方向
        Vector3 InputDir = new Vector3(horizontalInput, 0, verticalInput).normalized;
        var currentDir = InputDir * normalSpeed * Time.deltaTime;
        
        //告知rb组件前往的目标位置
        rb.MovePosition(transform.position + currentDir);
    }

    public void PlayHurt()
    {
        audioSource.Play();
    }
    public void onDie()
    {
        isDead = true;
        audioSource.clip = deathSFX;
        audioSource.Play();
        IsInputEnabled = false;
    }

    public void RestartLevel()
    {
        ScoreManager.score = 0;
        SceneManager.LoadSceneAsync(0);
        IsInputEnabled = true;
    }
}
