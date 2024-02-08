using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    public Rigidbody rigid;

	public float movePower;
	public float rotateSpeed;

	private Vector3 moveDir;

	private void Update()
	{
		Rotate();
	}
	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		Vector3 forceDir = transform.forward * moveDir.z;
		rigid.AddForce(forceDir * movePower, ForceMode.Force);
	}

	public void OnMove(InputValue value)
	{
		Vector2 inputDir = value.Get<Vector2>();
		moveDir.x = inputDir.x;
		moveDir.z = inputDir.y;
	}

	private void Rotate()
	{
		transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.World);
	}
}