using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject menuPanel, gamePanel, failPanel, successPanel;

    private void Start()
    {
        HideAllPanel();
        menuPanel.SetActive(true);
    }


    public void StartGameButton()
    {
        GameManager.Instance.StartGame();
        HideAllPanel();
        gamePanel.SetActive(true);
    }

    [System.Obsolete]
    public void RestartLevelButton()
    {
        GameManager.Instance.RestartLevel();
        HideAllPanel();
        gamePanel.SetActive(true);
        ScoreSystem.Instance.score = 0;
        Pooler.Instance.CreateWater();
    }

    public void NextLevelButton()
    {
        GameManager.Instance.NextLevel();
        HideAllPanel();
        gamePanel.SetActive(true);
    }

    public void Success()
    {
        HideAllPanel();
        successPanel.SetActive(true);
    }

    public void Fail()
    {
        HideAllPanel();
        failPanel.SetActive(true);
    }

    private void HideAllPanel()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        failPanel.SetActive(false);
        successPanel.SetActive(false);
    }
}
