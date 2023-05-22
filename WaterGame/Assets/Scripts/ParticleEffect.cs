using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParticleEffect : MonoBehaviour
{
    public ParticleSystem waterParticle;
    public TMP_Text duplicatorText;
    private void Start()
    {
        waterParticle.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        waterParticle.gameObject.SetActive(true);
        waterParticle.Play();        
        duplicatorText.fontSize = 60;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        duplicatorText.fontSize = 50;
    }
}
