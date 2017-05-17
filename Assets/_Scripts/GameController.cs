using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValue;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public int spawnCount;

	public float restartWait;

	public Text scoreText;
	public Text gameOverText;
	public Text restartText;

	private bool restart;
	private bool gameOver;
	private int score;

	void Start () 
	{
		UpdateScore ();
		gameOverText.text = "";
		restartText.text = "";

		StartCoroutine(SpawnWaves ());//执行协同程序
	}

	void Update(){
		if (restart && Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}
	
	//协同程序
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);

		while(true){//持续产生障碍物
			for (int i = 0; i < spawnCount; i++) {
				Vector3 spawnPos = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y,spawnValue.z);
				Instantiate (hazard, spawnPos, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if(gameOver){
				break;
			}
		}
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
		StartCoroutine (ShowRestart());

	}

	IEnumerator ShowRestart(){
		yield return new WaitForSeconds (restartWait);
		restart = true;
		restartText.text = "Press 'R' For Restart";
	}

	public void AddScore(int addValue)
	{
		score += addValue;
		UpdateScore ();
	}

	public void UpdateScore()
	{
		scoreText.text = "score: " + score;
	}
}
