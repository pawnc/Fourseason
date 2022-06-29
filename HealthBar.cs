using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    private PlayerHurt HealthCurrent;
    public static int healthCurrent;
    public static int healthMax;

    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
       
        healthMax = 8;
    }

    // Update is called once per frame
    void Update()
    {
        HealthCurrent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHurt>();
        healthCurrent = HealthCurrent.playerhealth;
        healthBar.fillAmount = (float)healthCurrent / (float)healthMax;
        healthText.text = healthCurrent.ToString() + "/" + healthMax.ToString();
    }
}
