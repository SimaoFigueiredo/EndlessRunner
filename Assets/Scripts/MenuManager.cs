using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject gameOverPanel;

    [Header("Text Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinsText;

    // Esta função agora pede 2 números quando o Player morre: a distância final e as moedas finais
    public void ShowGameOver(int finalDistance, int finalCoins)
    {
        // 1. Mostra o ecrã preto
        gameOverPanel.SetActive(true);

        // 2. Atualiza os textos com os valores dessa corrida
        scoreText.text = "Distância: " + finalDistance + "m";
        coinsText.text = "Moedas: " + finalCoins;

        int moedasAntigas = PlayerPrefs.GetInt("TotalCoins", 0); // Vê quanto tinhas
        PlayerPrefs.SetInt("TotalCoins", moedasAntigas + finalCoins); // Soma as novas
        PlayerPrefs.Save(); // Guarda no disco!

        // Vai procurar a gaveta chamada "HighScore". Se não existir, o valor é 0.
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0); 

        // Se a distância de agora for maior que o recorde antigo
        if (finalDistance > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", finalDistance); // Guarda o novo recorde
            PlayerPrefs.Save(); // Força a gravação no disco
            
            highScoreText.text = "HighScore: " + finalDistance + "m";
        }
        else
        {
            // Se não bate o recorde, mostra o recorde antigo
            highScoreText.text = "HighScore: " + savedHighScore + "m";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0); 
    }
    
}