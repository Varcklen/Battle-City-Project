using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _enemiesText;

    public static InfoPanel Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void SetHealth(int newHealth)
    {
        _healthText.text = newHealth.ToString();
    }

    public void SetScore(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }

    public void SetEnemiesLeft(int newAmount)
    {
        _enemiesText.text = newAmount.ToString();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
