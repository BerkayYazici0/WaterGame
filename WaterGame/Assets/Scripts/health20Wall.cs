using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class health20Wall : Singleton<health20Wall>
{
    [SerializeField] private int health;
    public TMP_Text healthText;
    public ParticleSystem steamParticle; 

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && health >= 2)
        {
            GameObject childObject = collision.gameObject.transform.GetChild(0).gameObject;
            collision.gameObject.transform.GetChild(0).gameObject.transform.localScale = new Vector3(2, 2, 2);
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            collision.gameObject.transform.GetChild(0).gameObject.transform.parent = null;
            childObject.transform.localScale = Vector3.one;
            Destroy(collision.gameObject);
            health--;
            healthText.text = "-" + health;
        }
        else if(collision.gameObject.CompareTag("Player") && health == 1)
        {
            Destroy(gameObject);
        }
    }
}
