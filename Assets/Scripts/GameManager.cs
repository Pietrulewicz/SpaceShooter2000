using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
        // Aktualizacja wyświetlacza punktów, jeśli taki istnieje
    }

    public void OnMysteryShipKilled(MysteryShip mysteryShip)
    {
        AddScore(mysteryShip.score);
    }
}
