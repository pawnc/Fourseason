using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Bat : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;
    

    public Transform movepPos;//变换组件 控制物体位置旋转缩放
    public Transform leftDownPos;
    public Transform rightUpPos;


    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movepPos.position = GetRandom();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();//调用父类update的方法

        transform.position = Vector2.MoveTowards(transform.position, movepPos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movepPos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movepPos.position = GetRandom();
                waitTime = startWaitTime;
                
            }
            else waitTime -= Time.deltaTime;
        }
        
    
    }

    Vector2 GetRandom()
    {
        Vector2 randpos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),Random.Range(leftDownPos.position.y,rightUpPos.position.y));
        return randpos;
    }
    
  
  
}