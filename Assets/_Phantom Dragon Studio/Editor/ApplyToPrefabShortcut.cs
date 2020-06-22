using UnityEngine;
using UnityEditor;

public class ApplyPrefabChanges : MonoBehaviour
{
    [MenuItem("Tools/Apply Prefab Changes %#x")]
    static public void applyPrefabChanges()
    {
        var obj = Selection.activeGameObject;
        if (obj != null)
        {
            var prefab_root = PrefabUtility.GetOutermostPrefabInstanceRoot(obj);
            var prefab_src = PrefabUtility.GetCorrespondingObjectFromSource(prefab_root);

            var path = AssetDatabase.GetAssetPath(prefab_src);
            if (prefab_src != null)
            {
                PrefabUtility.SaveAsPrefabAssetAndConnect(prefab_root, path, InteractionMode.AutomatedAction);
                Debug.Log("Updating prefab : " + AssetDatabase.GetAssetPath(prefab_src));
            }
            else if (prefab_src == null)
            {
                Debug.Log("Selected has no prefab, please create a base prefab first.");
            }
        }
        else
        {
            Debug.Log("Nothing selected");
        }
    }
}
