using UnityEngine;

namespace Framework
{
	public static class Objects
	{
		public static GameObject Instantiate(GameObject prefab)
		{
			var spawn = (GameObject)Instantiate (prefab, Vector3.zero, Quaternion.identity);	
			return spawn;
		}

		public static GameObject Instantiate(GameObject prefab, Vector3 position)
		{
			var spawn = (GameObject)Instantiate (prefab, position, Quaternion.identity);	
			return spawn;
		}

		public static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			var spawn = (GameObject)Instantiate (prefab, position, rotation);	
			return spawn;
		}
	}
}
