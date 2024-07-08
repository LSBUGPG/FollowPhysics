using UnityEngine;

public class TestMovement : MonoBehaviour
{
	[SerializeField] Rigidbody body;

	void Reset()
	{
		body = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Vector3 vector = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
		body.AddForce(vector * 10);
	}
}
