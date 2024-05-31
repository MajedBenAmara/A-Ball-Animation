using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform _startGamePanel;
    private RectTransform _endGamePanel;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void RemoveScreen()
    {
        Time.timeScale = 1f;
        _startGamePanel.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowEndGameScreen()
    {
        _endGamePanel.gameObject.SetActive(true);
    }
}
