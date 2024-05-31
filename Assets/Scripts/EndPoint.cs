using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField]
    private RectTransform _endGamePanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _endGamePanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
