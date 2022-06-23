using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
	public int reflections;
	public float maxLength;

	private LineRenderer lineRenderer;
	private Ray ray;
	private RaycastHit hit;
	private Vector3 direction;
	int i = 0;

	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
		this.enabled = false;
	}

	private void Update()
	{
		ray = new Ray(transform.position, transform.right);

		lineRenderer.positionCount = 1;
		lineRenderer.SetPosition(0, transform.position);
		float remainingLength = maxLength;

		for (int i = 0; i < reflections; i++)
		{
			if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
			{
				lineRenderer.positionCount += 1;
				lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
				remainingLength -= Vector3.Distance(ray.origin, hit.point);
				ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
				if (hit.collider.tag != "Mirror")
					break;
			}
			else
			{
				lineRenderer.positionCount += 1;
				lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
			}
		}


	}

	public void LaserOnOff()
	{
		i += 1;
		this.enabled = true;
		if (i % 2 == 1)
		{
			lineRenderer.enabled = false;
		}
		else
			lineRenderer.enabled = true;
	}
}
