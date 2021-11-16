using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] buildings;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public float radius;
    public bool stop;

    int randBuilding;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while(!stop)
        {
            randBuilding = Random.Range(0, buildings.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));

            if (DetectCollisions(spawnPosition) > 0)
                continue;
                
            Instantiate(buildings[randBuilding], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            buildings[randBuilding].transform.localScale = new Vector3(Random.Range(5.0f, 10.0f), Random.Range(5.0f, 10.0f), Random.Range(5.0f, 10.0f));
            buildings[randBuilding].transform.Rotate(new Vector3(0, Random.Range(1.0f, 90.0f), 0));

            yield return new WaitForSeconds(spawnWait);
        }
    }

    private int DetectCollisions(Vector3 pos)
    {
        Collider[] hitColliders = Physics.OverlapSphere(pos, radius);
        return hitColliders.Length;
    }   
}
