using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsPool : MonoBehaviour
{
    [SerializeField] private GameObject planetsPrefab;

    [SerializeField] private int poolSize = 5;
    private GameObject[] planets;

    [SerializeField] private float spawnTime = 2f;

    private float timeElapsed;
    private int planetCount;

    [SerializeField] private float xSpawnPosition = 6f;
    [SerializeField] private float minYPosition = -3.2f;
    [SerializeField] private float maxYPosition = 1.5f;

    void Start()
    {
        planets = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            planets[i] = Instantiate(planetsPrefab);
            planets[i].SetActive(false);
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnTime && !GameManager.Instance.isGameOver)
        {
            SpawnPlanet();
        }
    }

    private void SpawnPlanet()
    {
        timeElapsed = 0f;

        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2 (xSpawnPosition, ySpawnPosition);
        planets[planetCount].transform.position = spawnPosition;

        if (!planets[planetCount].activeSelf)
        {
            planets[planetCount].SetActive(true);
        }

        planetCount++;

        if (planetCount == poolSize)
        {
            planetCount = 0;
            if (spawnTime > 1.5f)
            {
                spawnTime -= 0.1f;
            }
        }
    }
}