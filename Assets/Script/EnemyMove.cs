using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class EnemyMove : MonoBehaviour {
	public float moveSpeed;

    void FixedUpdate() {
        Vector3 vec3 = transform.localPosition;
        vec3.x += moveSpeed * -1.0f;
        transform.localPosition = vec3;
    }
}
