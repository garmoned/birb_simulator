using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject building1;
    public GameObject building2;
    public GameObject building3;
    public GameObject building4;
    public GameObject building5;
    public GameObject building6;
    public GameObject building7;
    public GameObject building8;

    public int numberOfBuildings;

    public GameObject terrain;

    void Start()
    {
        GenerateObjects();
    }

    void Update()
    {

    }

    void GenerateObject(GameObject go, int amount)
    {
        if (go == null) return;

        for(int i = 0; i < amount; i++)
        {
            GameObject tmp = Instantiate(go);
            tmp.gameObject.transform.position = new Vector3(Random.Range(-1100.0f, 1000.0f), tmp.gameObject.transform.position.y, Random.Range(-900.0f, 1000.0f));
        }
    }

    void GenerateObjects()
    {
        GenerateObject(building1, numberOfBuildings);
        GenerateObject(building2, numberOfBuildings);
        GenerateObject(building3, numberOfBuildings);
        GenerateObject(building4, numberOfBuildings);
        GenerateObject(building5, numberOfBuildings);
        GenerateObject(building6, numberOfBuildings);
        GenerateObject(building7, numberOfBuildings);
        GenerateObject(building8, numberOfBuildings);
    }
}
