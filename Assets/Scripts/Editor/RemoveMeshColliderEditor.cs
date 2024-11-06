using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    [CustomEditor (typeof (MeshCollider))]
    public class RemoveMeshColiderEditor : MonoBehaviour
    {
        public override void OnInspectorGUI () {
		DrawDefaultInspector ();

		RemoveMeshCollider rmc = (RemoveMeshCollider) target;

		if (GUILayout.Button ("Remove ComponentName")) {
			rmc.RemoveComponents ();
		}
	}
    }
}
