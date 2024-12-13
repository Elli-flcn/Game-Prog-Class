using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyRunSpeed = 5f;
    [SerializeField] AudioClip dyingSFX; // Corrected from float to AudioClip

    Rigidbody2D enemyRigidBody2D;
    Animator enemyAnimator;

    void EnemyDyingSFX()
    {
        AudioSource.PlayClipAtPoint(dyingSFX, Camera.main.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Dying()
    {
        enemyAnimator.SetTrigger("Die");
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
