using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class RemoveMeshColider : MonoBehaviour
    {
        public void RemoveMeshColider()
        {
            MeshCollider[] components = GetComponentsInChildren (typeof (MeshCollider), true);

            foreach (var c in components) {
			    DestroyImmediate (c);
		    }
        }
    }
}
