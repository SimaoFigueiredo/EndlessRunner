using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    // A nossa função principal que cria o chão
    public void SpawnTile(bool spawnSemMoedas = false)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;

        // Se o spawner pedir, o chão desliga as moedas
        if (spawnSemMoedas)
        {
            temp.GetComponent<GroundTile>().podeCriarMoedas = false;
        }
    }

    private void Start()
    {
        // Cria 15 blocos no arranque
        for (int i = 0; i < 15; i++)
        {
            // Se for um dos primeiros 3 blocos, pede para não ter moedas
            SpawnTile(i < 1);
        }
    }
}