using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Image healthBar;
    private Moon moon;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        moon = GameObject.FindGameObjectWithTag("Moon").GetComponent<Moon>();
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (moon.privateHealth + 1) / (moon.health + 1), Time.deltaTime * speed);
    }
}
