using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
	public string nextScene;
	public TMP_Text interpolation;
	public Rigidbody ball;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Time.timeScale = 1;
			SceneManager.LoadScene(nextScene);
		}

		if (ball && interpolation)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (ball.interpolation == RigidbodyInterpolation.Interpolate)
				{
					ball.interpolation = RigidbodyInterpolation.None;
				}
				else
				{
					ball.interpolation = RigidbodyInterpolation.Interpolate;
				}
			}
			interpolation.text = ball.interpolation == RigidbodyInterpolation.Interpolate ? "Interpolation on" : "Interpolation off";
		}
	}
}
