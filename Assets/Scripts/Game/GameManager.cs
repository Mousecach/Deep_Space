using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	int EnemyCounter = 0;
	Transform TR;
	Transform SpawnPoint;

	public GameObject Enemy;

	void Start()
	{
		Invoke ("SpawnEnemy", 1);
		TR = transform;

		SpawnPoint = TR.GetChild (0).transform;
	}

	void SpawnEnemy()
	{
		EnemyCounter++;

		TR.Rotate (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));

		Instantiate (Enemy, SpawnPoint.position, SpawnPoint.rotation);

		Invoke ("SpawnEnemy", Random.Range (1f, 3f));
	}
}
