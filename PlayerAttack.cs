using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;

    private Animator anim;

    private PolygonCollider2D coll2D;

    public float time;

    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();

    }
   

    // Update is called once per frame
    void Update()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
        Attack();
        

    }
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            
            anim.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }
    }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
        

    }
    IEnumerator StartAttack()
    {
        
        yield return new WaitForSeconds(startTime);
        coll2D.enabled = true;
        StartCoroutine(disableHitBox());


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
                        
            other.GetComponent<Enemy>().TakeDamage(damage);


        }
        if ( other.gameObject.CompareTag("SpecialEnemy"))
        {

            other.GetComponent<MouseUp>().TakeDamage(damage);

        }
        if (other.gameObject.CompareTag("Frog"))
        {

            other.GetComponent<EnemyFrog>().TakeDamage(damage);


        }
    }
}
