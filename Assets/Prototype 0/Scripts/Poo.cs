using UnityEngine;
using System.Collections;

public class Poo : MonoBehaviour, IOnTap {

	public Transform           SpawnPosition;
	public Vector3               Step; 
	public GameObject       PooPrefab; 
	public GameObject       StandGraphics;
	public GameObject       BendGraphics;

	private GameObject  spawn;
	private bool               hasSpawned = false;
	private int                  numTaps;

	const int MAX_TAPS = 4;

	public void OnTap()
	{
		if(hasSpawned && spawn != null)
		{
			if(numTaps < MAX_TAPS)
			{
				numTaps++;
				spawn.transform.Translate(Step);
				SwitchGraphics (true);
			}
			else
			{
				hasSpawned = false;
				numTaps = 0;

				var body = spawn.GetComponent<Rigidbody2D>();
				body.SetKinematic (false);
				body.AddRandomForceOnX (3, 5, true, ForceMode2D.Impulse);
			}
		}
		
		if (!hasSpawned)
		{
			spawn = Framework.Objects.Instantiate (PooPrefab, SpawnPosition.position, SpawnPosition.localRotation);
			SwitchGraphics (false);
			hasSpawned = true;
		}
	}

	void SwitchGraphics(bool ToBend)
	{
		BendGraphics.SetActive (ToBend);
		StandGraphics.SetActive (!ToBend);
	}
}
