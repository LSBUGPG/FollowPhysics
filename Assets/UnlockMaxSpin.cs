using UnityEngine;

public class UnlockMaxSpin : MonoBehaviour
{
	public Rigidbody body;

	void Start()
	{
		body.maxAngularVelocity = Mathf.Infinity;
	}
}
