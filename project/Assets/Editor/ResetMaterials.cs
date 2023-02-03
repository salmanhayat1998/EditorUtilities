using UnityEngine;
using UnityEditor;

public class ResetMaterials : Editor
{
    [MenuItem("Tools/My/Find Standard Shaders %;")]
    public static void FindShader()
    {
        MeshRenderer[] meshRenderers = FindObjectsOfType<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            Material[] materials = meshRenderer.sharedMaterials;

            foreach (Material material in materials)
            {
               // if(material.name.Contains(" (in)"))
                var matName = material.name.Replace(" (Instance)","");
                meshRenderer.material.name = matName;
                //Debug.Log(material.name);
                //if (material.name == "Standard")
                //{
                   
                //}
            }
        }
    }
}