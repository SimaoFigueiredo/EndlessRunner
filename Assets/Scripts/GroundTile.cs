using UnityEngine;
using System.Collections.Generic;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    [Header("Spawns")]
    public GameObject coinPrefab;
    public GameObject[] obstaclePrefabs; 
    public Transform[] spawnPoints;
    public GameObject estrelaPrefab; 

    [Header("Configurações")]
    [Range(0, 100)] 
    public float chanceDeEstrela = 10f; 
    public bool podeCriarMoedas = true;
    public float alturaBaseMoedas = 0f; 

    // A nossa "Lista" para guardar tudo o que este bloco criar
    List<GameObject> elementosCriados = new List<GameObject>();

    void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();

        if (podeCriarMoedas)
        {
            SpawnElementos();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.name == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 3f);
        }
    }

    // Quando o chão for destruído, destrói TUDO o que está na lista dele!
    private void OnDestroy()
    {
        foreach (GameObject obj in elementosCriados)
        {
            if (obj != null) Destroy(obj);
        }
    }

    void SpawnElementos()
    {
        int faixaSegura = Random.Range(0, spawnPoints.Length);
        bool saltoObrigatorio = Random.Range(0, 100) < 60;
        bool[] faixaOcupada = new bool[spawnPoints.Length];

        // 1. MOEDAS E SALTO
        if (Random.Range(0, 100) < 90) 
        {
            faixaOcupada[faixaSegura] = true; 
            Transform pontoMoedas = spawnPoints[faixaSegura];
            
            for (int i = 0; i < 5; i++)
            {
                float alturaExtra = 0f;
                if (saltoObrigatorio)
                {
                    if (i == 0) alturaExtra = 0f;
                    else if (i == 1) alturaExtra = 1.2f;
                    else if (i == 2) alturaExtra = 1.8f;
                    else if (i == 3) alturaExtra = 1.2f;
                    else if (i == 4) alturaExtra = 0f;
                }

                // Usamos a tua nova variável 'alturaBaseMoedas'
                Vector3 posMoeda = pontoMoedas.position + new Vector3(0, alturaBaseMoedas + alturaExtra, (i * 2.5f) - 2f);
                GameObject m = Instantiate(coinPrefab, posMoeda, Quaternion.identity);
                
                elementosCriados.Add(m); 
            }
        }
        else if (saltoObrigatorio) 
        {
            faixaOcupada[faixaSegura] = true; 
        }

        // 2. OBSTÁCULOS
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i == faixaSegura) 
            {
                if (saltoObrigatorio) SpawnObstaculoEspecifico(obstaclePrefabs[1], spawnPoints[i]);
                continue;
            }

            if (Random.Range(0, 100) < 95) 
            {
                faixaOcupada[i] = true; 
                int tipo = Random.Range(0, obstaclePrefabs.Length);
                SpawnObstaculoEspecifico(obstaclePrefabs[tipo], spawnPoints[i]);
            }
        }

        // 3. ESTRELA
        if (Random.Range(0f, 100f) < chanceDeEstrela)
        {
            List<int> faixasVazias = new List<int>();
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (!faixaOcupada[i]) faixasVazias.Add(i);
            }

            if (faixasVazias.Count > 0)
            {
                int escolha = faixasVazias[Random.Range(0, faixasVazias.Count)];
                
                // A estrela também usa a mesma altura base das moedas
                Vector3 posEstrela = spawnPoints[escolha].position + new Vector3(0, alturaBaseMoedas, 0); 
                GameObject e = Instantiate(estrelaPrefab, posEstrela, Quaternion.identity);
                
                elementosCriados.Add(e); 
            }
        }
    }

    void SpawnObstaculoEspecifico(GameObject prefab, Transform ponto)
    {
        Vector3 pos = new Vector3(ponto.position.x, transform.position.y, ponto.position.z);
        GameObject novo = Instantiate(prefab, pos, Quaternion.identity);
        
        float altura = novo.GetComponent<Collider>().bounds.size.y;
        novo.transform.position += new Vector3(0, altura / 2f, 0);
        
        elementosCriados.Add(novo); 
    }
}