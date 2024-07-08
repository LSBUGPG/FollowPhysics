using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public Transform target;
	public float pitch = -30f;
	public float distance = 10f;

	void Start()
	{
		Application.targetFrameRate = 60;
	}

	void Update()
	{
		Quaternion direction = Quaternion.Euler(0, 0, pitch);
		Vector3 position = target.position - direction * Vector3.right * distance;
		transform.position = position;
		transform.LookAt(target.position);
	}
}
