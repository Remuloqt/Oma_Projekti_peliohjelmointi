 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator anim;
	
	bool fired = false;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float jumpForce = 700f;
	
	GameObject standCollider;
	GameObject crouchCollider;
	GameObject standWeapon;
	GameObject crouchWeapon;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		standCollider = transform.FindChild("Stand Collider").gameObject;
        crouchCollider = transform.FindChild("Crouch Collider").gameObject;
		standWeapon = transform.FindChild("ProjectileSpawn Stand").gameObject;
        crouchWeapon = transform.FindChild("ProjectileSpawn Crouch").gameObject;
        crouchCollider.SetActive(false);
		crouchWeapon.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetBool ("Fired", fired);
		
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);

		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}
	}

	void Update()
	{

		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Crouch", false);
			anim.SetBool ("Ground", false);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
		} 
		else if (grounded && Input.GetKeyDown (KeyCode.DownArrow)) {
			anim.SetBool ("Crouch", true);
			standCollider.SetActive(false);
            crouchCollider.SetActive(true);
			standWeapon.SetActive(false);
            crouchWeapon.SetActive(true);
		} 
		else if (grounded && Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.SetBool ("Crouch", false);
			crouchCollider.SetActive(false);
            standCollider.SetActive(true);
			standWeapon.SetActive(true);
            crouchWeapon.SetActive(false);

		}
		else if(Input.GetButtonDown("Fire1"))
		{
			anim.SetBool ("Fired", true);
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
}
