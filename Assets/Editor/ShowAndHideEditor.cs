using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ShowAndHide))]
public class ShowAndHideEditor : Editor
{
		public override void OnInspectorGUI()
		{
				DrawDefaultInspector();

				ShowAndHide myScript = (ShowAndHide)target;
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