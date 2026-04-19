using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    [Header("Spawns")]
    public GameObject coinPrefab;
    public Transform[] coinSpawnPoints;
    
    public bool podeCriarMoedas = true; 

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

        if (podeCriarMoedas)
        {
            SpawnCoins();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.gameObject.name == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 2f);
        }
    }

    void SpawnCoins()
    {
        // 1. Lança o dado: Este bloco de chão vai ter moedas? 
        if (Random.Range(0, 100) < 75) // 75% de chance de ter moedas
        {
            // 2. Escolhe APENAS UMA faixa ao calhas (0 = Esquerda, 1 = Centro, 2 = Direita)
            int faixaEscolhida = Random.Range(0, coinSpawnPoints.Length);
            Transform pontoBase = coinSpawnPoints[faixaEscolhida];

            // 3. Define quantas moedas vão formar o corredor
            int moedasNaFila = 5;

            // 4. Cria a fila de moedas a ir para a frente
            for (int i = 0; i < moedasNaFila; i++)
            {
                // Adicionamos '-2f' para a fila começar 2 metros mais cedo no bloco
                Vector3 posicaoMoeda = pontoBase.position + new Vector3(0, 0, (i * 2.5f) - 2f);

                Instantiate(coinPrefab, posicaoMoeda, Quaternion.identity);
            }
        }
    }
}