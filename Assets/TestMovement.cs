using UnityEngine;

public class TestMovement : MonoBehaviour
{
	[SerializeField] Rigidbody body;
	Vector3 vector;

	void Reset()
	{
		body = GetComponent<Rigidbody>();
	}

	void Update()
	{
		vector.x = Input.GetAxis("Vertical");
		vector.z = -Input.GetAxis("Horizontal");
	}

	void FixedUpdate()
	{
		body.AddForce(vector * 10);
	}
}
