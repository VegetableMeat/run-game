using System.Linq;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {
	[SerializeField] private float imageWidth;
	private Transform[] childrenTransform;
	private Vector3 resetPos;
	private float loopPos;
	public float moveSpeed;

	void Awake() {
		// 子要素を取得する、取得するとき自身のオブジェクトも取得してしまうため除外する
		childrenTransform = transform.GetComponentsInChildren<Transform>().Where(child => child.gameObject != transform.gameObject).ToArray();
		// 背景画像のリセット位置を設定、背景画像の1番目はカメラに移らない場所に配置する
		resetPos = childrenTransform[0].position;
		// 背景画像をループさせる位置を設定
		loopPos = resetPos.x - imageWidth * 2.0f;
	}

	private void FixedUpdate() {
		foreach (var background in childrenTransform) {
			background.MovePosition(moveSpeed);

			if (background.localPosition.x <= loopPos) {
				background.ResetPosition(resetPos);
			}
		}
	}
}

public static class BackGroundMoveExtensions {
	// 設定されている速度に応じて背景画像を移動
	public static void MovePosition(this Transform self, float moveSpeed) {
		Vector3 movePos = self.localPosition;
		movePos.x += moveSpeed * -1.0f;
		self.localPosition = movePos;
	}
	// 背景画像をリセット位置へ移動
	public static void ResetPosition(this Transform self, Vector3 resetPos) {
		self.localPosition = resetPos;
	}
}
