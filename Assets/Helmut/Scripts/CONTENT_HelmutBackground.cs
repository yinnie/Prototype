using UnityEngine;
using System.Collections;

public class CONTENT_HelmutBackground : ScrollingBackground
{
	public GameObject Prefab;

	#region implemented abstract members of ScrollingBackground
	
	public override void GenerateGraphics ()
	{
		var newPrefab = Instantiate(Prefab, transform.position, transform.rotation) as GameObject;
		newPrefab.transform.parent = transform;
	}
	
	public override float CalculateScrollSpeed ()
	{
		return AbsoluteScrollSpeed;
	}
	
	public override int CalculateScrollDirection ()
	{
		return -1;
	}
	
	public override void SpawnNewLandscape ()
	{
		var obj = new GameObject();
		obj.name = name;
		obj.transform.parent = transform.parent;
		obj.transform.position = 
			new Vector3(rightEdge, transform.position.y, 0);
		
		var cluster = obj.AddComponent<CONTENT_HelmutBackground>();
		
		cluster.AbsoluteScrollSpeed = AbsoluteScrollSpeed;
		cluster.scrollDirection = scrollDirection;
		
		cluster.Prefab = Prefab;
		
		cluster.TargetMin = TargetMin;
		cluster.TargetMax = TargetMax;
		
		cluster.Width = Width;
		cluster.Height = Height;
		cluster.GenerateOnStart = GenerateOnStart;
		cluster.Dimension = Dimension;
	}
	
	#endregion

}
