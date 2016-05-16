using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance;

	public int EnemyCounter = 0;
	public int MaxEnemies = 15;
	int score = 0;
	Transform TR;
	Transform SpawnPoint;
	public GameObject Player;

	public Text RocketTime;
	public GameObject RocketInfo;
	public float TimeToShoot;

	public GameObject Enemy;

	public int Score
	{
		get
		{
			return score;
		}
	}

	public void SetBlinckOnRocketInfo(bool IsBlink)
	{
		RocketInfo.GetComponent<Blink> ().enabled = IsBlink;
		if(!IsBlink)
		{
			RocketInfo.GetComponent<Image> ().color = Color.white;
			RocketTime.color = Color.white;
		}
	}

	void FixedUpdate()
	{
		if(TimeToShoot >= 0)
		{
			TimeToShoot -= Time.deltaTime;
			if(TimeToShoot < 0)
				TimeToShoot = 0;
		}

		if (TimeToShoot == 0)
			RocketTime.text = "0:00";
		else if (TimeToShoot < 10 && TimeToShoot != 0)
			RocketTime.text = "0:0" + (int)TimeToShoot;
		else 
			RocketTime.text = "0:" + (int)TimeToShoot;
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
		if(EnemyCounter < MaxEnemies)
		{
			EnemyCounter++;

			TR.Rotate (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));

			Instantiate (Enemy, SpawnPoint.position, SpawnPoint.rotation);
		}

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
