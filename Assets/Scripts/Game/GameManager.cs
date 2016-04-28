using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance;

	public int EnemyCounter = 0;
	int score = 0;
	Transform TR;
	Transform SpawnPoint;
	public GameObject Player;

	public GameObject Enemy;

	public int Score
	{
		get
		{
			return score;
		}
	}

	void Start()
	{
		Instance = this;

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

	public void EnemyDown(int id = 0)
	{
		EnemyCounter--;

		if(id == 0)
		{
			score += 10;
		}
	}
}
