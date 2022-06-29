using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject dialogBox2;
    public Text dialogBoxText;
    public Text dialogBoxText2;
    public string signtext;
    public string signtext2;
    private bool isPlayerInside;
  
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPlayerInside)
        {
            dialogBox.SetActive(true);
            dialogBoxText.text = signtext;
            
        }
        
        else
        {
            dialogBox.SetActive(false);
            dialogBox2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInside)
        {
            dialogBox.SetActive(false);
            dialogBox2.SetActive(true);
            dialogBoxText2.text = signtext2;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInside = false;
        }
    }
    
    


}
