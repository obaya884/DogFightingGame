using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    public Collider weaponCollider;

    NavMeshAgent agent;
    Animator animator;

    int maxHp = 100;
    int hp = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.destination = target.position;
        HideColliderWeapon();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
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
        takeDamage(weaponManager.damage);
        Debug.Log("Enemy is Damaged!");
        animator.SetTrigger("Hurt");
    }

    void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        Debug.Log("Enemyの残りHP：" + hp);
    }
}
