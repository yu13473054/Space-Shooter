﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValue;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public int spawnCount;

	public Text scoreText;
	private int score;

	void Start () {
		UpdateScore ();

		StartCoroutine(SpawnWaves ());//执行协同程序
	}
	
	//协同程序
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);

		while(true){//持续产生障碍物
			for (int i = 0; i < spawnCount; i++) {
				Vector3 spawnPos = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y,spawnValue.z);
				Instantiate (hazard, spawnPos, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void AddScore(int addValue){
		score += addValue;
		UpdateScore ();
	}

	public void UpdateScore(){
		scoreText.text = "score: " + score;
	}
}