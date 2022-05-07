using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 3;
    public Collider weaponCollider;
    public PlayerUIManager playerUIManager;

    Rigidbody rigidbody;
    Animator animator;

    float x;
    float z;
    int maxHp = 100;
    int currentHp = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        HideColliderWeapon();
        currentHp = maxHp;
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

    public void HideColliderWeapon()
    {
        weaponCollider.enabled = false;
    }

    public void ShowColliderWeapon()
    {
        weaponCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        WeaponManager weaponManager = other.GetComponent<WeaponManager>();
        if (weaponManager == null) { return; }
        Debug.Log("Player is Damaged!");
        takeDamage(weaponManager.damage);
        animator.SetTrigger("Hurt");
    }

    void takeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
        }
        playerUIManager.UpdateHp(currentHp);
        Debug.Log("Playerの残りHP：" + currentHp);
    }
}
