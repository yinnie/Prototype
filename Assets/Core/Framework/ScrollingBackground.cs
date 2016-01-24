using UnityEngine;
using System.Collections;

/// <summary>
/// Managing endless scrolling type of asset re-generation
/// based on Sky's scrolling landscape
/// </summary>
public abstract class ScrollingBackground : MonoBehaviour
{
	public enum ScrollDimension
	{
		Horizontal,
		Vertical
	}

	public float   AbsoluteScrollSpeed = 0;
	public float   Width = 10F;
	public float   Height = 10F;

	public Transform TargetMax;
	public Transform TargetMin;
	public ScrollDimension  Dimension;

	protected int   scrollDirection = -1;

	bool  hasSpawnedNext = false;
	float speed;
	public bool GenerateOnStart;

	public virtual void Awake ()
	{
		speed = AbsoluteScrollSpeed;
	}

	public virtual void Start () 
	{
		if(GenerateOnStart)
		{
			GenerateGraphics();
		}
//		var rigid = gameObject.AddComponent<Rigidbody2D>();
//		rigid.isKinematic = true;
//		rigid.mass = 10000;
	}

	public abstract void GenerateGraphics();

	public virtual void Update () 
	{
		speed = CalculateScrollSpeed();
		scrollDirection = CalculateScrollDirection();
		Move();
		SpawnNew();
	}

	public virtual void Move()
	{
		float xTravel =  speed * Time.smoothDeltaTime;
		Vector3 newPos = new Vector3(
			transform.localPosition.x + scrollDirection * xTravel, transform.localPosition.y, 0);
		transform.localPosition = newPos;
	}

	public abstract float CalculateScrollSpeed();

	public abstract int CalculateScrollDirection();

	public virtual void SpawnNew()
	{
		if(Dimension == ScrollDimension.Horizontal)
		{
			if(scrollDirection == -1)
			{
				// moving towards left
		        if(!hasSpawnedNext && rightEdge < XBoundaryMax)	
				{
					hasSpawnedNext = true;

					// spawn new cluster
					SpawnNewLandscape();
				}

				if(hasSpawnedNext & rightEdge < XBoundaryMin)
				{
					Destroy(gameObject.gameObject);
				}
			} else if(scrollDirection == 1)
			{
				// moving towards right
		        if(!hasSpawnedNext && rightEdge > XBoundaryMin)	
				{
					hasSpawnedNext = true;

					// spawn new cluster
					SpawnNewLandscape();
				}

				if(hasSpawnedNext & rightEdge > XBoundaryMax)
				{
					Destroy(gameObject.gameObject);
				}
			}
		} else 
		{
	        if(!hasSpawnedNext && topEdge < YBoundaryMax)	
			{
				hasSpawnedNext = true;

				// spawn new cluster
				SpawnNewLandscape();
			}

			if(hasSpawnedNext & topEdge < YBoundaryMin)
			{
				Destroy(gameObject.gameObject);
			}
		}
	}


	public abstract void SpawnNewLandscape();


	#region Properties
	public virtual float rightEdge
	{
		get 
		{
			return transform.TransformPoint(new Vector3(Width, 0, 0)).x;
		}
	}
	public virtual float topEdge
	{
		get
		{
			return transform.TransformPoint(new Vector3(0, Height,0)).y;
		}
	}

	public virtual float XBoundaryMax
	{
		get
		{
			return TargetMax.position.x;
		}
	}

	public virtual float YBoundaryMax
	{
		get
		{
			return TargetMax.position.y;
		}
	}

	public virtual float XBoundaryMin
	{
		get
		{
			return TargetMin.position.x;
		}
	}

	public virtual float YBoundaryMin
	{
		get
		{
			return TargetMin.position.y;
		}
	}
	#endregion


	#if UNITY_EDITOR
	protected void OnDrawGizmos() 
	{
		Color c = Color.blue;
		if (!Application.isPlaying)
		{
			var matrix = Gizmos.matrix;
			Gizmos.matrix = transform.localToWorldMatrix;

			var center = new Vector2(Width / 2F, Height / 2F);
			var size = new Vector2(Width, Height);
			
			Gizmos.color = new Color(1, 1, 1, 0);
			
			Gizmos.DrawCube(center, size);

			Gizmos.color = c;
			
			Gizmos.DrawWireCube(center, size);
			
			Gizmos.matrix = matrix;

			Gizmos.color = Color.white;
		}
		else
		{
			Gizmos.color = c;
			if(Dimension == ScrollDimension.Horizontal)
			{
				Gizmos.color = Color.red;
				Vector3 center = new Vector3(XBoundaryMax, transform.position.y, 0);
				Gizmos.DrawLine(center + Vector3.up * 10, center + Vector3.up * -10);

//				Gizmos.color = Color.white;
//				Vector3 min = new Vector3(XBoundaryMin, transform.position.y, 0);
//				Gizmos.DrawLine(min + Vector3.up * 10, min + Vector3.up * -10);

			Gizmos.color = Color.green;
				Vector3 right = new Vector3(rightEdge, transform.position.y, 0);
				Gizmos.DrawLine(right + Vector3.up * 10, right + Vector3.up * -10);
			} else {
				Gizmos.color = Color.red;
				Vector3 center = new Vector3(transform.position.x, YBoundaryMax, 0);
				Gizmos.DrawLine(center + Vector3.right * 10, center + Vector3.right * -10);

//				Gizmos.color = Color.yellow;
//				Vector3 min = new Vector3(transform.position.x, YBoundaryMin, 0);
//				Gizmos.DrawLine(min + Vector3.right * 10, min + Vector3.right * -10);

				Gizmos.color = Color.green;
				Vector3 right = new Vector3(transform.position.x, topEdge, 0);
				Gizmos.DrawLine(right + Vector3.right * 10, right + Vector3.right * -10);
			}
		}
	}
	#endif

}
