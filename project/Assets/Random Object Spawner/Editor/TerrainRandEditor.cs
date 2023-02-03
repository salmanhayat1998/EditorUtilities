using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TerrainRand))]
public class TerrainRandEditor : Editor
{
	override public void OnInspectorGUI()
	{
		TerrainRand terrain = target as TerrainRand;	
		terrain.prefab = EditorGUILayout.ObjectField("Prefab", terrain.prefab, typeof(GameObject)) as GameObject;
		terrain.count = EditorGUILayout.IntField("Count", terrain.count);
		terrain.randomRotationX = EditorGUILayout.FloatField("Random X", terrain.randomRotationX);
		terrain.randomRotationY = EditorGUILayout.FloatField("Random Y", terrain.randomRotationY);
		terrain.randomRotationZ = EditorGUILayout.FloatField("Random Z", terrain.randomRotationZ);
		if (GUILayout.Button("Generate"))
		{
			//Generate(terrain);
			Generate(terrain);
		}
	}
	
    void Generate(TerrainRand tr)
	{
     
        if (tr.prefab == null)
		{
			Debug.Log("prefab is null");
			return;
		}
        GameObject parent = new GameObject("objects");
        Transform myTransform = tr.transform;
        for (int i = 0; i < tr.count; i++)
        {
            Vector3 pos = myTransform.position;
            Collider collider = myTransform.GetComponent<Collider>();
            Vector3 newpos = new Vector3();
            newpos.x = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            newpos.y = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            newpos.z = Random.Range(collider.bounds.min.z, collider.bounds.max.z);
            newpos.y = GetYCoordinate(newpos);
            pos = newpos;
            Quaternion rot = Quaternion.Euler(Random.Range(-tr.randomRotationX, tr.randomRotationX), Random.Range(-tr.randomRotationY, tr.randomRotationY), Random.Range(-tr.randomRotationZ, tr.randomRotationZ));
            GameObject gameObject = PrefabUtility.InstantiatePrefab(tr.prefab) as GameObject;
            gameObject.transform.position = pos;
            gameObject.transform.rotation = rot;
            gameObject.transform.SetParent(parent.transform);
        }

    }
    float GetYCoordinate(Vector3 point)
    {
        Ray ray = new Ray(new Vector3(point.x, 1000, point.z), Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2000, LayerMask.GetMask("Default")))
        {
            
            return hit.point.y;
        }
        return 0;
    }
}
