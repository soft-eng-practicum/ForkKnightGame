using UnityEngine;
using System.Collections;

public class MasterSpawnScript : MonoBehaviour {

    public GameObject[] spawnprefab;
    public float spawnTime = 5f;	
	public float spawnDelay = 3f;	
    public bool stopPrefabSpawn = true;
    public int count;
    public Score score;
    public int start;
    public int x = 0;
    public int stoppage;
     
    // Use this for initialization
    void Start()
    {
        count = (spawnprefab.Length) / 3;
        stoppage = count;
        score = GameObject.Find("Score").GetComponent<Score>();
        InvokeRepeating("BeginSpawn", spawnDelay, spawnTime);
    }

    void Update()
    {
        if (score.score >= x*100)
        {
            start += count;
            stoppage += count;
            InvokeRepeating("BeginSpawn", spawnDelay, spawnTime);
        }
    }

    void BeginSpawn()
    {
        if (stoppage > spawnprefab.Length)
            stoppage = spawnprefab.Length;
        for(int i=start;i<stoppage;i++)
        {
            spawnprefab[i].GetComponent<SpawnerScript>().Start();
        }
        x += 2 * x + 1;
    }
}