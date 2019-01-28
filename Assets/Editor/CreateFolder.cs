using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
public class Create : MonoBehaviour
{

    [MenuItem("Tools/CreateFolder")]
    static void CreateFolder()
    {

        string path = "Assets";
        Debug.Log("开始创建:" + path);

        AssetDatabase.CreateFolder(path, "Models");
        AssetDatabase.CreateFolder(path, "Editor");
        AssetDatabase.CreateFolder(path, "Scripts");
        AssetDatabase.CreateFolder(path, "Scenes");
        AssetDatabase.CreateFolder(path, "UI");
        AssetDatabase.CreateFolder(path, "Mats");
        AssetDatabase.CreateFolder(path, "Textures");
        AssetDatabase.CreateFolder(path, "Resources");
        AssetDatabase.CreateFolder(path, "Plugins");
        AssetDatabase.CreateFolder(path, "Prefabs");

        Debug.Log("创建成功");
    }
    [MenuItem("Tools/SetTexture")]
    static void SetTexture()
    {
        Object matgo = Selection.activeObject;
        Debug.Log(matgo.name);
        Material mat = matgo as Material;

        string goname = matgo.name;

        List<Texture> textures = new List<Texture>();
        foreach (var item in Resources.LoadAll<Texture>("image"))
        {
            if (item.name.StartsWith(goname))
            {
                string[] strs = item.name.Split('_');
                string endStr = strs[strs.Length - 1];
                if (endStr == "Color")
                {
                    mat.SetTexture("_MainTex", item);
                }
                else if (endStr == "Metallic")
                {
                    mat.SetTexture("_MetallicGlossMap", item);
                }
                else if (endStr == "AO")
                {
                    mat.SetTexture("_OcclusionMap", item);
                }
                else if (endStr == "Normal")
                {
                    mat.SetTexture("_BumpMap", item);
                }
            }
        }
    }
}
