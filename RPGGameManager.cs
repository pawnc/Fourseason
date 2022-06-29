using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RPGGameManager : MonoBehaviour
{
    public SpawnPoint PlayerSpawnPoint;
    public static RPGGameManager shareInstance=null;

    private PlayerHurt playerHealth;

    private void Awake()
    {
        if(shareInstance!=null&&shareInstance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            shareInstance = this;
        }
    }
    private void Start()
    {
        SetupScene();
        
    }
    public void SetupScene()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        if(PlayerSpawnPoint!=null)
        {
            GameObject player = PlayerSpawnPoint.SpawnObject();
        }
    }
    public void Update()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHurt>();
        if (playerHealth.playerhealth==0)
        {
            GameObject player = PlayerSpawnPoint.SpawnObject();
            playerHealth.playerhealth = 8;

        }
    }

}
