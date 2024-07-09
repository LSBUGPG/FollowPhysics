using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Graph : MonoBehaviour
{
	public LineRenderer line;
	public Transform target;
	public Camera graphCamera;
	public string filename;
	Vector3 position;
	float velocity;
	float acceleration;

	public float width = 5.0f;
	public float yScale = 10f;
	public int steps = 700;
	public float margin = 0.1f;
	int current = 0;
	float dx;
	float offsetX;
	float start;

	List<float> displacements = new List<float>();
	List<float> times = new List<float>();
	Vector3 startPosition;

	void ConfigureLineRenderer(LineRenderer lineRenderer, int steps, Color color)
	{
		lineRenderer.positionCount = steps;
		lineRenderer.startWidth = width;
		lineRenderer.endWidth = width;
		lineRenderer.startColor = color;
		lineRenderer.endColor = color;

		for (int i = 0; i < steps; ++i)
		{
			lineRenderer.SetPosition(i, new Vector3(i * dx - offsetX, 0, 0));
		}
	}

	void Start()
	{
		float aspect = graphCamera.aspect;
		offsetX = graphCamera.orthographicSize * (1f - margin) * aspect;
		dx = offsetX * 2f / steps;
		ConfigureLineRenderer(line, steps, Color.red);
		position = target.position;
		velocity = 0;
		acceleration = 0;
		start = Time.time;
	}

	void Update()
	{
		float t = Time.time;
		float dt = Time.deltaTime;
		float v = (target.position - position).magnitude / dt;
		acceleration = (v - velocity) / dt;
		velocity = v;
		position = target.position;

		if (current == 0)
		{
			startPosition = position;
		}

		if (t > start + 1f && current < steps)
		{
			line.SetPosition(current, new Vector3(current * dx - offsetX, acceleration * yScale, 0));
			displacements.Add(Vector3.Distance(startPosition, position));
			times.Add(t);
			current++;
		}

		if (current == steps)
		{
			Time.timeScale = 0;
			using (StreamWriter file = new StreamWriter($"{Path.Combine(Application.persistentDataPath,filename)}"))
			{
				file.WriteLine("Time, Displacement");
				for (int i = 0; i < displacements.Count; ++i)
				{
					file.WriteLine($"{times[i]}, {displacements[i]}");
				}
			}
		}
	}
}
