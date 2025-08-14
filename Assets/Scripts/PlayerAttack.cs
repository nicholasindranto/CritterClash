using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // reference ke animator attackcollider sama attackdurationnya
    public Animator animator;
    public GameObject attackCollider;
    public float attackDuration = 0.5f;

    private void Update()
    {
        // kalau lagi attack maka
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetBool("isAttacking", true); // jalankan animasinya
        attackCollider.SetActive(true); // aktifkan collidernya

        Invoke("EndAttack", attackDuration);
    }

    private void EndAttack()
    {
        // ketika attacknya selesai, maka
        attackCollider.SetActive(false); // matiin collidernya
        animator.SetBool("isAttacking", false); // matikan animasinya
    }
}
