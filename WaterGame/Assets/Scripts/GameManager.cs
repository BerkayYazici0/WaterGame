using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameStatus gameStatus;
    [Header("Level")]
    [SerializeField] private GameObject[] levels;
    [SerializeField] private GameObject currentLevel;
    [SerializeField] private int currentLevelIndex;
    private void Start()
    {
        gameStatus = GameStatus.MENU;
        currentLevelIndex = 0;
        LevelLoad();
        Time.timeScale = 0f;
    }

    private void LevelLoad()
    {
        if (currentLevel)
        {
            Destroy(currentLevel);
        }

        if(currentLevelIndex >= levels.Length)
        {
            currentLevelIndex = 0;
        }

        currentLevel = Instantiate(levels[currentLevelIndex]);
    }

   public void Fail()
    {
        UIManager.Instance.Fail();
        gameStatus = GameStatus.FAIL;
    }

    public void Success()
    {
        UIManager.Instance.Success();
        gameStatus = GameStatus.SUCCESS;
    }

    public void NextLevel()
    {
        gameStatus = GameStatus.PLAY;
        currentLevelIndex++;
        LevelLoad();
    }

    public void RestartLevel()
    {
        gameStatus = GameStatus.PLAY;
        SceneManager.LoadScene("Game");        
    }

    public void StartGame()
    {
        gameStatus = GameStatus.PLAY;
        Time.timeScale = 1f;

        for(int i = 0; i < Pooler.Instance.waterObjects.Count; i++)
        {
            Pooler.Instance.waterObjects[i].SetActive(true);
        }
    }

    public enum GameStatus
    {
        MENU,
        PLAY,
        FAIL,
        SUCCESS
    }
}
