using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	
	public GameObject spawnee;
	public float spawnAreaBreadth;
	public float spawnAreaDepth;
	
	private int spawnCounter;
	public int spawnFreq;
	public int spawnFreqRandom;
	
	private List<GameObject> spawns = new List<GameObject>();
	
	// Use this for initialization
	void Start ()
	{
		spawnCounter = spawnFreq + Random.Range(-spawnFreqRandom, spawnFreqRandom);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void EndTurn()
	{
		SendMessageToAllSpawns("EndTurn");
		
		spawnCounter--;
		if(spawnCounter <= 0)
		{
			spawnCounter = spawnFreq + Random.Range(-spawnFreqRandom, spawnFreqRandom);
			CreateSpawn();
		}
	}
	
	public void StartTurn()
	{
		SendMessageToAllSpawns("StartTurn");
	}
	
	private void SendMessageToAllSpawns(string msg)
	{
		for(int i = 0; i < spawns.Count; i++)
		{
			if(spawns[i] == null || !spawns[i].GetComponent<Health>().isAlive)
				spawns.RemoveAt(i--);
			else
				spawns[i].SendMessage(msg);
		}
	}
	
	public void CreateSpawn()
	{
		GameObject go = GameObject.Instantiate(spawnee) as GameObject;
		spawns.Add(go);
		//go.transform.parent = transform;
		Vector3 pos = transform.position;
		pos.x += Random.Range(-spawnAreaBreadth, spawnAreaBreadth);
		pos.y = transform.position.y;
		pos.z += Random.Range(-spawnAreaDepth, spawnAreaDepth);
		go.transform.position = pos;
	}
}
