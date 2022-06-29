using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUp : MonoBehaviour
{
    private Animator mouseAnime;

    public int health;

    public float flashTime;

    private SpriteRenderer sr;

    private Color originalColor;

    private PlayerHurt playerHealth;

    

    // Start is called before the first frame update
    void Start()
    {
        mouseAnime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); 
        originalColor = sr.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
        FlashColor(flashTime);
    }
    public void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.CompareTag("Player") && collsion.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            mouseAnime.SetBool("Up", true);
            
        }
        else
        {
            mouseAnime.SetBool("Up", false);
        }
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
}
