using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab; // O pedaço de chão (o teu prefab azul)
    public Transform playerTransform; // O teu Player (Cápsula)
    
    private float zSpawn = 0; 
    private float tileLength = 30; // O comprimento do teu chão no eixo Z
    private int numberOfTiles = 6; // Quantos pedaços de chão queres ativos ao mesmo tempo
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        // Cria os primeiros pedaços de chão ao iniciar o jogo
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // Se o jogador avançar o suficiente, cria um novo chão e apaga o mais antigo
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    public void SpawnTile()
    {
        // Instancia o novo chão na posição correta
        GameObject go = Instantiate(tilePrefab, transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        // Remove o chão que já ficou para trás para não pesar no PC
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}