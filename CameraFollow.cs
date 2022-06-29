using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float smoothing;

    public Vector2 minPos;
    public Vector2 maxPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()// 移动代码在update里，跟随在laterupdate
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if(target !=null)
        {
            if(transform.position!=target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
       
    }
    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        this.minPos = minPos;
        this.maxPos = maxPos;
    }
}
