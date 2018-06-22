using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -180.0f;
    private float tileLength = 180.0f;
    private float safeZone = 180.0f;
    private int amnTilesOnScreen = 10;

    private List<GameObject> activeTiles;

    public GameObject[] ObstaclePrefabs;
    private int ObstaclesToSpawnPerTile = 7;
    private Vector3 RandomSpawnPlace;

    public GameObject PersonPrefab;
    public int PeopleToSpawnPerTile = 20;
    // Use this for initialization
    void Start()
    {
        activeTiles = new List<GameObject>();
        

        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update () {
        playerTransform = GameObject.Find("Player(Clone)").transform.Find("RubberRunner").transform;
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            ObstaclesToSpawnPerTile = Random.Range(12, 18);
            SpawnTile();
            DeleteTile();
        }
	}

    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);


        for (int i = 0; i < ObstaclesToSpawnPerTile; i++)
        {          
            RandomSpawnPlace = new Vector3(Random.Range(go.transform.position.x - 20, go.transform.position.x + 20), 0, Random.Range(go.transform.position.z - 180, go.transform.position.z + 180));
            GameObject obs;
            obs = Instantiate(ObstaclePrefabs[Random.Range(0, 5)]) as GameObject;
            obs.transform.SetParent(transform);
            obs.transform.position = RandomSpawnPlace;
        }

        for (int j = 0; j < PeopleToSpawnPerTile; j++)
        {
            RandomSpawnPlace = new Vector3(Random.Range(go.transform.position.x - 20, go.transform.position.x + 20), 0, Random.Range(go.transform.position.z - 180, go.transform.position.z + 180));
            GameObject person;
            person = Instantiate(PersonPrefab) as GameObject;
            person.transform.SetParent(transform);
            person.transform.position = RandomSpawnPlace;
        }
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        //PlayerController.score++;
    }
}
