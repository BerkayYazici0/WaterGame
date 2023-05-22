using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDuplicated : MonoBehaviour
{       
    [SerializeField] private bool isDuplicatedd = false;
    
    private void Start()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("2x"))
        {
            if (!isDuplicatedd)
            {
                Vector3 spawnLoc = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y - 0.2f, collision.gameObject.transform.position.z);
                Instantiate(gameObject, spawnLoc, Quaternion.identity);
                isDuplicatedd = true;
            }
        }
        else if (collision.gameObject.CompareTag("3x"))
        {
            if (!isDuplicatedd)
            {
                Vector3 spawnLoc = new Vector3(collision.transform.position.x, collision.transform.position.y - 0.2f, collision.transform.position.z);
                Instantiate(gameObject, spawnLoc, Quaternion.identity);
                spawnLoc.x += .1f;
                Instantiate(gameObject, spawnLoc, Quaternion.identity);
                isDuplicatedd = true;
            }
        }        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("2x") || collision.gameObject.CompareTag("3x"))
        {                
                isDuplicatedd = false;
        }

    }
}
