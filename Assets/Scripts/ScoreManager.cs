using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    private int totalMoedas = 0;

    void Start()
    {
        AtualizarEcra();
    }

    public void ApanhouMoeda()
    {
        totalMoedas++; // Soma 1 moeda
        AtualizarEcra(); // Atualiza a imagem
    }

    void AtualizarEcra()
    {
        textoPontuacao.text = totalMoedas.ToString();
    }
}