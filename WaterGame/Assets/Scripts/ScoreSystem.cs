using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : Singleton<ScoreSystem>
{
    [SerializeField] private GameObject[] waters;
    [SerializeField] private List<GameObject> Waters;
    public bool isSuccessed;
    public int score = 0;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           
            score++;
        }
    }
    private void Start()
    {
        isSuccessed = false;
    }
    private void Update()
    {
        waters = GameObject.FindGameObjectsWithTag("Player");
        Waters = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        Debug.Log(score);
        for(int i = 0; i < Waters.Count; i++)
        {
            if(Waters[i].transform.position.y < -18.5f)
            {
                Waters.RemoveAt(i);
                if(Waters.Count == waters.Length / 2 && score <= 75)
                {
                    UIManager.Instance.Fail();
                }
            }
        }

        if (!isSuccessed && score > 75)
        {
            UIManager.Instance.Success();
            isSuccessed = true;
        }
    }
}
