using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnSemMoedas = false)
{
    // 1. Cria o chão
    GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
    Transform pontoDeSaida = temp.transform.Find("SpawnPoint");

    if (pontoDeSaida != null)
    {
        nextSpawnPoint = pontoDeSaida.position;
    }
    else
    {
        Debug.LogError("CUIDADO: Não encontrei o objeto chamado 'SpawnPoint' dentro do Prefab!");
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    // 3. Lógica das moedas
    if (spawnSemMoedas)
    {
        temp.GetComponent<GroundTile>().podeCriarMoedas = false;
    }
}

    private void Start()
    {
        nextSpawnPoint = new Vector3(0, 0, 10);
        // Cria 15 blocos no arranque
        for (int i = 0; i < 15; i++)
        {
            // Se for um dos primeiros 1 blocos, pede para não ter moedas
            SpawnTile(i < 4);
        }
    }
}