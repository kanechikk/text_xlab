using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Golf
{
    [CustomEditor (typeof (RemoveMeshCollider))]
    public class RemoveMeshColliderEditor : Editor
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
