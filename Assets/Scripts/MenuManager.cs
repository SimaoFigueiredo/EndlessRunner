using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Ecrãs de UI")]
    public GameObject painelGameOver;

    public void MostrarGameOver()
    {
        // Torna o ecrã preto e o botão visíveis
        painelGameOver.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        // Lê o nome da cena atual e carrega-a de novo (faz "Reset" a tudo)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}