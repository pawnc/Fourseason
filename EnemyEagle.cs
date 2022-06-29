using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagle : Enemy
{
    private GameObject Player;

    private Animator PlayerAnime;

    private Transform PlayerPos;
    public Transform MovePos;

    private bool isPretending;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerAnime = Player.GetComponent<Animator>();
        PlayerPos = Player.transform;
       
        if(Vector2.Distance(transform.position,PlayerPos.position)<20.0f)
        {
            if (isPretending)
            { 
                transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, speed * Time.deltaTime);
            }
            if(!isPretending)
            {
                transform.position = Vector2.MoveTowards(transform.position, MovePos.position, speed * Time.deltaTime);
            }
        }
        GetBool();


    }
    void GetBool()
    {
        if (Input.GetButtonDown("PretendDeath"))
        {
            isPretending = true;
        }
        if(Input.GetButtonDown("Attack"))
        {
            isPretending = false;
        }
    }
}
