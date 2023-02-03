using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GameEconomyandStats : MonoBehaviour
{
    static string stArea = "Empty List";
    [MenuItem("Tools/My/Reset Score")]
    static void ResetScore()
    {
        PlayerPrefs.SetInt("score",5000);
        PlayerPrefs.Save();
    }
    [MenuItem("Tools/My/Give Cash")]
    static void GiveCash()
    {
        PlayerPrefs.SetInt("score", 1000000);
        PlayerPrefs.Save();

    } 
    [MenuItem("Tools/My/Standard shader")]
    static void getAllshaders()
    {
        FindShader("Standard");
       
    }
    [MenuItem("Tools/My/Unlock All Levels")]
    static void UnlockLevels()
    {
        PlayerPrefs.SetInt("OpenLevels", 25);
        PlayerPrefs.Save();
    }  
    [MenuItem("Tools/My/Unlock All planes")]
    static void UnlockPlanes()
    {
        PlayerPrefs.SetInt("unlockallplanes",1);
        PlayerPrefs.Save();
    }
    private static void FindShader(string shaderName)
    {
        int count = 0;
        //stArea = "Materials using shader " + shaderName + ":\n\n";

        List<Material> armat = new List<Material>();

        Renderer[] arrend = (Renderer[])Resources.FindObjectsOfTypeAll(typeof(Renderer));
        foreach (Renderer rend in arrend)
        {
            foreach (Material mat in rend.sharedMaterials)
            {
                if (!armat.Contains(mat))
                {
                    Debug.Log(rend.gameObject.name);
                    armat.Add(mat);
                }
            }
        }
        foreach (Material mat in armat)
        {
            if (mat != null && mat.shader != null && mat.shader.name != null && mat.shader.name == shaderName)
            {
                Debug.Log("name "+mat.name);
                stArea += ">" + mat.name + "\n";
                count++;
            }
        }

        stArea += "\n" + count + " materials using shader " + shaderName + " found.";
        Debug.Log(stArea);
    }
    #region Individual Levels
    [MenuItem("Tools/My/Unlock Individual Levels/Level 2")]
    static void UnlockLevel2()
    {
        PlayerPrefs.SetInt("OpenLevels", 1);
        PlayerPrefs.Save();
    }
      [MenuItem("Tools/My/Unlock Individual Levels/Level 3")]
    static void UnlockLevel3()
    {
        PlayerPrefs.SetInt("OpenLevels", 2);
        PlayerPrefs.Save();
    }
    [MenuItem("Tools/My/Unlock Individual Levels/10 Levels")]
    static void Unlock10Level()
    {
        PlayerPrefs.SetInt("OpenLevels", 9);
        PlayerPrefs.Save();
    }
    [MenuItem("Tools/My/Unlock Individual Levels/15 Levels")]
    static void Unlock15Level()
    {
        PlayerPrefs.SetInt("OpenLevels", 14);
        PlayerPrefs.Save();
    } 


    #endregion
}
