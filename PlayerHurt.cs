using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public int playerhealth;
    private Animator myAnim;
    public float flashtime;
    public float waittime;
    public float flashTime;
    public float dietime;
    private SpriteRenderer sr;
    private Color OriginalColor;


    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        OriginalColor = sr.color;
    }
    
    // Update is called once per frame
    void Update()
    {
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void DamageToPlayer(int damage)
    {
        if (playerhealth >= 1)
        {
            playerhealth -= damage;
            Hit();
            FlashColor(flashTime);

        }
        if(playerhealth < 0)
        {
            playerhealth = 0;
        }
        
        

        if (playerhealth<=0)
        {
            Invoke("Die", dietime);
            Invoke("PlayerDie", waittime);
        }
    }
    public void Hit()
    {
        myAnim.SetTrigger("hit");
    }
    public void Die()
    {
        myAnim.SetTrigger("die");
    }
    public void PlayerDie()
    {
        Destroy(gameObject);
    }
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);

    }
    void ResetColor()
    {
        sr.color = OriginalColor;
    }

}
