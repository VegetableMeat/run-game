using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Destroyer : MonoBehaviour {
    [SerializeField] private GameObject enemy;

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == enemy.tag) {
			Destroy(collision.gameObject);
		}
	}
}
