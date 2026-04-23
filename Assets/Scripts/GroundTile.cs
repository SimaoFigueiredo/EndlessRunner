using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    [Header("Spawns")]
    public GameObject coinPrefab;
    public GameObject[] obstaclePrefabs; 
    public Transform[] spawnPoints;
    
    public bool podeCriarMoedas = true; 

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

        if (podeCriarMoedas)
        {
            SpawnElementos();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.gameObject.name == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 3f);
        }
    }

    void SpawnElementos()
    {
        // 1. ESCOLHER A FAIXA SEGURA (A que o jogador tem de usar para sobreviver)
        int faixaSegura = Random.Range(0, spawnPoints.Length);

        // % de chance da faixa segura ter uma barreira baixinha
        bool saltoObrigatorio = Random.Range(0, 100) < 60;

        // 2. ESCOLHER ONDE FICAM AS MOEDAS (Para guiar o jogador para a segurança)
        // % de chance de haver moedas na faixa segura
        if (Random.Range(0, 100) < 90) 
        {
            Transform pontoMoedas = spawnPoints[faixaSegura];
            int moedasNaFila = 5;

            for (int i = 0; i < moedasNaFila; i++)
            {
                float alturaExtra = 0f;

                // Se houver barreira, desenhamos um arco com as moedas!
                if (saltoObrigatorio)
                {
                    if (i == 0) alturaExtra = 0f;       // Chão
                    else if (i == 1) alturaExtra = 1.2f; // A subir
                    else if (i == 2) alturaExtra = 1.8f; // Ponto mais alto (por cima da barreira)
                    else if (i == 3) alturaExtra = 1.2f; // A descer
                    else if (i == 4) alturaExtra = 0f;   // Chão
                }

                // Adicionamos a alturaExtra no eixo Y
                Vector3 posicaoMoeda = pontoMoedas.position + new Vector3(0, alturaExtra, (i * 2.5f) - 2f);
                Instantiate(coinPrefab, posicaoMoeda, Quaternion.identity);
            }
        }

        // 3. ESCOLHER ONDE FICA O PERIGO (Nas faixas que sobram)
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Se estivermos a olhar para a faixa segura:
            if (i == faixaSegura) 
            {
                // Se calhou o salto obrigatório, pomos a barreira baixinha
                if (saltoObrigatorio)
                {
                    Transform pontoObstaculo = spawnPoints[i];
                    
                    // Força o Y a ser exatamente o nível do chão
                    Vector3 posicaoChao = new Vector3(pontoObstaculo.position.x, transform.position.y, pontoObstaculo.position.z);
                    
                    GameObject novoObstaculo = Instantiate(obstaclePrefabs[1], posicaoChao, Quaternion.identity);
                    
                    // Calcula a altura real e cola os pés ao chão
                    float altura = novoObstaculo.GetComponent<Collider>().bounds.size.y;
                    novoObstaculo.transform.position += new Vector3(0, altura / 2f, 0);
                }
                
                // Ignoramos o resto (não pomos paredes grandes na faixa segura)
                continue;
            }

            // % de chance de haver um obstáculo nesta faixa específica
            if (Random.Range(0, 100) < 85) 
            {
                Transform pontoObstaculo = spawnPoints[i];
                
                // Sorteia entre a Parede (0) e o Salto (1)
                int tipoObstaculo = Random.Range(0, obstaclePrefabs.Length);
                
                // Força o Y a ser exatamente o nível do chão
                Vector3 posicaoChao = new Vector3(pontoObstaculo.position.x, transform.position.y, pontoObstaculo.position.z);
                
                // Faz nascer o obstáculo
                GameObject novoObstaculo = Instantiate(obstaclePrefabs[tipoObstaculo], posicaoChao, Quaternion.identity);
                
                // Calcula a altura real e cola os pés ao chão
                float altura = novoObstaculo.GetComponent<Collider>().bounds.size.y;
                novoObstaculo.transform.position += new Vector3(0, altura / 2f, 0);
            }
        }
    }
}