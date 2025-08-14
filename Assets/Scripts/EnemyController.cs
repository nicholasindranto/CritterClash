using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // reference ke collider rigidbody dan animator si enemy
    public CapsuleCollider2D capcoll;
    public Rigidbody2D rb;
    public Animator anim;

    // durasi animasi matinya
    public float deathDuration = 1.0f;

    // reference ke playernya
    private Transform player;

    // kecepatan lari enemynya
    private float moveSpeed;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        moveSpeed = LevelManager.Instance.level;
    }

    private void Update()
    {
        if (player != null)
        {
            // langsung jalan menuju ke player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // atur enemynya menghadap kemana
            if (player.position.x > transform.position.x) // player dikanan enemy
            {
                // hadap kanan
                transform.localScale = new Vector3(-3, 3, 3); // basisnya dia hadap kiri, makanya negatif
            }
            else
            {
                // hadap kiri
                transform.localScale = new Vector3(3, 3, 3);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide with : " + collision.gameObject.name);
        // kalau dia nabrak atau nyentuh attack collidernya karakter maka hilang
        if (collision.gameObject.tag == "AttackCollider")
        {
            Debug.Log("kena coy serangannya");
            // matiin dulu rigidbody dan collidernya biar gak mengenai karakter kita lagi
            rb.isKinematic = true;
            capcoll.enabled = false;

            // tambah score sebesar levelnya ketika kill enemy
            GameManager.Instance.AddScore(LevelManager.Instance.level);

            PlayDeathAnimation();
        }
    }

    private void PlayDeathAnimation()
    {
        // play animasinya sesuai nama enemynya
        if ((gameObject.name.Contains("Boar")) || (gameObject.name.Contains("Bee")))
        {
            anim.SetBool("isHit", true);
        }
        else if (gameObject.name.Contains("Snail"))
        {
            anim.SetBool("isDead", true);
        }

        StartCoroutine(Death()); // baru hancurin gameobjectnya
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(deathDuration);
        Destroy(gameObject);
    }
}
