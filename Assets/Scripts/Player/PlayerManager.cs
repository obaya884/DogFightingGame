using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator animator;

    float x;
    float z;
    public float moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // キーボード入力で移動
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        // 攻撃入力
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }

    }

    private void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(x, 0, z) * moveSpeed;
        Vector3 direction = transform.position + moveVector;

        transform.LookAt(direction); // 方向転換
        rigidbody.velocity = moveVector; // 速度設定
        animator.SetFloat("MoveSpeed", rigidbody.velocity.magnitude); // アニメーション切り替え
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player is Damaged!");
    }
}
