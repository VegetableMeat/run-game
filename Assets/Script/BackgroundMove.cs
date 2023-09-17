using System.Linq;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {
	[SerializeField] private float imageWidth;
	private Transform[] childrenTransform;
	private Vector3 resetPos;
	private float loopPos;
	public float moveSpeed;

	void Awake() {
		// �q�v�f���擾����A�擾����Ƃ����g�̃I�u�W�F�N�g���擾���Ă��܂����ߏ��O����
		childrenTransform = transform.GetComponentsInChildren<Transform>().Where(child => child.gameObject != transform.gameObject).ToArray();
		// �w�i�摜�̃��Z�b�g�ʒu��ݒ�A�w�i�摜��1�Ԗڂ̓J�����Ɉڂ�Ȃ��ꏊ�ɔz�u����
		resetPos = childrenTransform[0].position;
		// �w�i�摜�����[�v������ʒu��ݒ�
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
	// �ݒ肳��Ă��鑬�x�ɉ����Ĕw�i�摜���ړ�
	public static void MovePosition(this Transform self, float moveSpeed) {
		Vector3 movePos = self.localPosition;
		movePos.x += moveSpeed * -1.0f;
		self.localPosition = movePos;
	}
	// �w�i�摜�����Z�b�g�ʒu�ֈړ�
	public static void ResetPosition(this Transform self, Vector3 resetPos) {
		self.localPosition = resetPos;
	}
}
