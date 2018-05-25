// C# Example
// Builds an asset bundle from the selected objects in the project view.
// Once compiled go to "Menu" -> "Assets" and select one of the choices
// to build the Asset Bundle

using UnityEngine;
using UnityEditor;

public class ExportAssetBundles 
{
    [MenuItem("Assets/Build AssetBundle From Selection - Track dependencies")]
    static void ExportResource () {
		
        // Bring up save panel
        string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
        if (path.Length != 0) {
            // Build the resource file from the active selection.
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android);
            Selection.objects = selection;
        }
    }
    [MenuItem("Assets/Build AssetBundle All Selected As Individual bundles - Track dependencies ")]
    static void ExportResourceIndividual () {
		
        // Bring up save panel
        string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
 //       if (path.Length != 0) {
            // Build the resource file from the active selection.
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

			string pathWithoutEndBit = path.Substring(0,path.Length - 9);		
		
			foreach(Object thisObject in selection)
			{
				//in the save dialogue give it a name 1 letter long...
			
				string pathPerItem = pathWithoutEndBit + thisObject.name + ".unity3d";
			
				Object[] fakeSelection = {thisObject};
			
				BuildPipeline.BuildAssetBundle(thisObject,fakeSelection, pathPerItem, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android);
			}
		    Selection.objects = selection;
		
  //      }
    }
//	[MenuItem("Assets/Build AssetBundle From Selection - No dependency tracking")]
//    static void ExportResourceNoTrack () {
//        // Bring up save panel
//        string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
//        if (path.Length != 0) {
//            // Build the resource file from the active selection.
//            BuildPipeline.BuildAssetBundle(Selection.activeObject, Selection.objects, path);
//        }
//    }
}