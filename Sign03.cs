using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign03 : MonoBehaviour
{
    public GameObject dialogBox;

    public Text dialogBoxText;

    public string signtext;

    private bool isPlayerInside;

    public GameObject Trap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isPlayerInside)
        {
            Trap.SetActive(true);
            dialogBoxText.text = signtext;
            dialogBox.SetActive(true);

        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInside = false;
            dialogBox.SetActive(false);
        }
    }





}