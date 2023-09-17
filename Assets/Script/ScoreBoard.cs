using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
	private float seconds;
	public int score;
	public Text scoreText;

	void Start() {
		score = 0;
		seconds = 0f;
	}

	void Update() {
		seconds += Time.deltaTime;
		if (seconds >= 0.1f) {
			score++;
			scoreText.text = score.ToString();
			seconds = seconds - 0.1f;
		}
	}
}
