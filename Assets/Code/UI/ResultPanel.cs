using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _pointsAmount;
    [SerializeField] private string winString;
    [SerializeField] private string loseString;

    public static ResultPanel Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetResults(bool isWin)
    {
        gameObject.SetActive(true);
        _resultText.text = isWin ? winString : loseString;
        _pointsAmount.text = GameManager.Instance.Score.ToString();
    }

    public void RetryStart()
    {
        gameObject.SetActive(false);
        WorldCreator.Instance.GenerateNewWorld();
        GameManager.Instance.SetScore(0);
        InfoPanel.Instance.Show();
    }
}
