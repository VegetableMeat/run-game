using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float gravity;
	public float jumpSpeed;
	public float jumpHeight;
	public AnimationCurve jumpCurve;
	public GameManager gm;

	[SerializeField] private Animator anim;
	[SerializeField] private Rigidbody2D rb;
	private bool isGround;
	private bool isJump;
	private float jumpTime;
	private float maxJumpTime;
	private float ySpeed;

	void Start()
	{
		isGround = true;
		isJump = false;
		jumpTime = 0.0f;
		maxJumpTime = 1.0f;
}

	void Update()
	{
		ySpeed = -gravity;

		// 地面に付いてる状態でSpaceキーか画面を押すとジャンプフラグがTrueになる
		if (isGround && (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)))
		{
			isJump = true;
			isGround = false;
		}

		if (isJump)
		{
			// ジャンプ中に入力を離すか指定の秒数が経ったらジャンプフラグをFalseにする
			if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space) || jumpTime >= maxJumpTime)
			{
				isJump = false;
				jumpTime = 0.0f;
			}

			if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
			{
				ySpeed = jumpSpeed;
				jumpTime += Time.deltaTime;
			}
		}
	}

	void FixedUpdate()
	{
		if (isJump || !isJump && !isGround)
		{
			jump();
		}
	}

	void jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, 0);
		float power = ySpeed * jumpCurve.Evaluate(jumpTime);
		rb.AddForce(power * Vector2.up, ForceMode2D.Impulse);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
		{
			isGround = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		// TODO: ジャンプ連打をするとコリジョンが反応しなくなるバグがあるので、OnTriggerでも接地判定を取る（後に修正）
		if (collision.gameObject.CompareTag("Floor")) 
		{
			isGround = true;
		}

		if (collision.gameObject.CompareTag("GameOver"))
		{
			gm.GameOver();
		}
	}
}