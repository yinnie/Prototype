using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{
	#region Rigidbody2D

	public static void SetKinematic(this Rigidbody2D body, bool ToKinematic)
	{
		body.isKinematic = ToKinematic;
		if(ToKinematic)
		{
			body.interpolation = RigidbodyInterpolation2D.None;
			body.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
		}
		else {
			body.interpolation = RigidbodyInterpolation2D.Interpolate;
			body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		}
	}

	public static void AddRandomForceOnX(this Rigidbody2D body, float Min, float Max, bool randDirection, ForceMode2D mode)
	{
		int direction = 1;
		if(randDirection)
		{
			direction = (Random.value > 0.5f) ? 1 : -1;
		}
		float x = Random.Range (Min, Max); 
		body.AddForce (new Vector2 (direction * x, 0), mode);
	}

	public static void AddRandomForceOnY(this Rigidbody2D body, float Min, float Max, bool randDirection, ForceMode2D mode)
	{
		int direction = 1;
		if(randDirection)
		{
			direction = (Random.value > 0.5f) ? 1 : -1;
		}
		float y = Random.Range (Min, Max); 
		body.AddForce (new Vector2 (0, direction * y), mode);
	}

	#endregion
}
