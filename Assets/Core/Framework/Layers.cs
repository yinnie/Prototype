using UnityEngine;
using System.Collections;

namespace Thingiebox {

		public class Layers {

			public static bool isGameObjectinLayerMask(GameObject obj, LayerMask mask)
			{
				int objMask = 1 << obj.layer;
				if ((mask.value & objMask) > 0)
					return true;
				else
					return false;
			}

			public static void setLayerRecursively(GameObject obj, int layerNum)
			{
				if (obj == null || layerNum < 0)
				{
					return;
				}

				obj.layer = layerNum;

				foreach (Transform child in obj.transform)
				{
					Layers.setLayerRecursively(child.gameObject, layerNum);
				}
			}

	}

}

