using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour


{
    public Transform LeftPos;
    public Transform RightPos;
    public Transform MovePos;
    public float speed;
    private Rigidbody2D myRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, MovePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, LeftPos.position) < 0.1f)
        {
            MovePos.position = RightPos.position;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Vector2.Distance(transform.position, RightPos.position) < 0.1f)
        {
            MovePos.position = LeftPos.position;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        


    }
    

}

    
