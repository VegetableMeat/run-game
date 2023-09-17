using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class EnemyController : MonoBehaviour {
    [SerializeField] private GameObject _groundEnemy;
	[SerializeField] private GameObject _skyEnemy;
	[SerializeField] private List<Vector3> _groundEnemyPos;
	[SerializeField] private Vector3 _skyEnemyPos;

	void Update() {
		if (Time.timeScale > 0 && Time.frameCount % 600 == 0) {
			if (selectPopEnemy() == 0) {
				Vector3 vec3 = _skyEnemyPos;
				vec3.y += (selectPopEnemy(3)) * 30;
				Instantiate(_skyEnemy, vec3, Quaternion.identity);
			}
			else {
				switch (selectPopEnemy())
				{
					case 2:
						Instantiate(_groundEnemy, _groundEnemyPos[2], Quaternion.identity);
						goto case 1;
					case 1:
						Instantiate(_groundEnemy, _groundEnemyPos[1], _groundEnemy.transform.rotation * Quaternion.Euler(0, -180f, 0));
						goto case 0;
					case 0:
						Instantiate(_groundEnemy, _groundEnemyPos[0], Quaternion.identity);
						break;
				}
			}
		}
	}

	private int selectPopEnemy(int num = 3) {
		return Random.Range(0, num);
	}
}