using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private bool gameover;

	void Start()
    {
		gameover = false;
	}

    void Update()
    {
		if (gameover && (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)))
		{
			Scene activeScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(activeScene.name);
			Time.timeScale = 1;
		}
	}

	public void GameOver()
	{
		gameover = true;
		Time.timeScale = 0;
	}
}
