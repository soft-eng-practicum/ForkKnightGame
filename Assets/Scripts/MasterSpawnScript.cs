using UnityEngine;
using System.Collections;

public class MasterSpawnScript : MonoBehaviour {

    public GameObject[] spawnprefab; // contains all the spawners
    public float spawnTime = 5f;	// if we want to delay all the spawners to a certain degree
	public float spawnDelay = 3f;	// or change the initial time it spawns
    public int count; // 3 levels, count will be 1/3 of the number of spawners, and active 1/3 of spawners per level
    public Score score; // score to keep track of when we want the spawners to spawn
    public int x;
    public int start; // starting point for spawner
    public int stoppage; // initially used to stop spawners, but now to cut off which spawners we want to use
	private int level = 0;
    // Use this for initialization
    void Start()
    {
        count = (spawnprefab.Length) / 3;// 1/3 of spawners (3 levels)
        stoppage = count; // first 3 spawners
        score = GameObject.Find("Score").GetComponent<Score>(); //get the score
        InvokeRepeating("BeginSpawn", spawnDelay, spawnTime); //start the spawn
    }

    void Update()
    {
        if (score.score >= (x*100)+100) //scores of 100
        {
			x = x + 5;
			start += count;
			stoppage += count;
            if (stoppage <= spawnprefab.Length) // prevent array out of bounds
                 InvokeRepeating("BeginSpawn", spawnDelay, spawnTime);
        }
    }

    void BeginSpawn()
    {

        for(int i=start;i<stoppage;i++)
        {
            spawnprefab[i].GetComponent<SpawnerScript>().Start(); // spawn from start -> stoppage ( so 0 -2, then 2 -5, etc)
        }
 
    }
}