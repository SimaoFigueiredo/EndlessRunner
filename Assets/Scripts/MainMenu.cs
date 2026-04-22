using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject painelComoJogar;
    public TextMeshProUGUI totalMoedasText;

    void Start()
    {
        // Logo que o jogo abre, vai ao banco ver quantas moedas temos
        int moedasGuardadas = PlayerPrefs.GetInt("TotalCoins", 0);
        
        // Atualiza o texto no ecrã (se o tiveres ligado no Inspector)
        if (totalMoedasText != null)
        {
            totalMoedasText.text = moedasGuardadas.ToString();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Função para abrir as instruções
    public void AbrirComoJogar()
    {
        painelComoJogar.SetActive(true);
    }

    // Função para fechar as instruções
    public void FecharComoJogar()
    {
        painelComoJogar.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("A sair do jogo...");
        
        #if UNITY_EDITOR // sair do modo de jogo dentro do unity
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // sair caso o jogo seja exportado para um ficheiro .exe
            Application.Quit();
        #endif
    }
}