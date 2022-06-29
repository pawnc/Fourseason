using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : MonoBehaviour
{
    public int damage;

    public int health;

    public float flashTime;

    public GameObject Bleeding;

    private SpriteRenderer sr;

    private Color originalColor;

    private PlayerHurt playerHealth;

    public GameObject poison;




    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHurt>();
        sr = GetComponent<SpriteRenderer>(); //怪血量变红 记录原颜色
        originalColor = sr.color;

    }

    // Update is called once per frame
    public void Update()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHurt>();
        if (health <= 0)
        {
            poison.SetActive(true);
            Destroy(gameObject);

        }
    }
    public void TakeDamage(int damage)
    {

        health -= damage;
        FlashColor(flashTime);
        Instantiate(Bleeding, transform.position, Quaternion.identity);



    }
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);

    }
    void ResetColor()
    {
        sr.color = originalColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerHealth != null)
                playerHealth.DamageToPlayer(damage);
        }
    }
}
