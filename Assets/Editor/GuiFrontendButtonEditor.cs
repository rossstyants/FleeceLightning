using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GuiFrontendButton))]
public class GuiFrontEndButtonEditor : Editor
{
		public override void OnInspectorGUI()
		{
				DrawDefaultInspector();

				GuiFrontendButton myScript = (GuiFrontendButton)target;
				if(GUILayout.Button("Show"))
				{
						myScript.Show();
				}
				if(GUILayout.Button("Hide"))
				{
						myScript.Hide();
				}
		}
}