using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // hp nya
    public int hp = 10;

    // reference ke dan animatornya
    private Animator animator;

    // lamanya animasi death
    public float deathDuration = 1.5f;

    // reference ke text HP nya
    public TMP_Text hpText;

    // reference ke gameplaycontroller
    public GameplayController gpControl;

    private void Awake()
    {
        animator = GetComponent<Animator>(); // ambil dulu komponen animatornya
    }

    private void Start()
    {
        UpdateHPText(); // biar ui hp nya ada
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // kalau dia nyentuh enemy, maka kurangi HP nya
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= LevelManager.Instance.level;

            // kalau HP nya <= 0, maka mati, jalankan fungsi death
            if (hp <= 0)
            {
                animator.SetBool("isDead", true); // jalankan animasinya

                // matiin rigidbody sama collidernya
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<CapsuleCollider2D>().enabled = false;

                // matiin timer pas mati
                // gpControl.isCounting = false;

                StartCoroutine(Death());
            }

            UpdateHPText();
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(deathDuration); // tunggu death animationnya
        Destroy(gameObject);

        // lose
        gpControl.GameLose();
    }

    private void UpdateHPText()
    {
        hpText.text = "HP: " + hp; // update text HP nya sesuai dengan hp yang tersisa
    }
}
