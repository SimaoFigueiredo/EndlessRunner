using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile; 
    private Vector3 nextSpawnPoint; 

    void Start()
    {
        // Quando o jogo começa, cria logo 5 bocados de pista seguidos para o jogador não cair
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        // Cria uma cópia do chão na posição "nextSpawnPoint"
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        
        // Calcula onde vai ser o próximo bocado.
        // Como no início esticámos o Plane (Scale Z = 10), ele tem 100 metros de comprimento no Unity.
        // Então dizemos: o próximo chão vai nascer 100 metros mais à frente!
        nextSpawnPoint = nextSpawnPoint + new Vector3(0, 0, 100f);
    }
}