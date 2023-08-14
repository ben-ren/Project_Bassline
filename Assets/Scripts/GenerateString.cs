using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateString : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfPrefabs;
    public Transform startPoint;
    public Transform endPoint;

    private List<GameObject> prefabList = new List<GameObject>();

    public void Generate()
    {
        ClearGeneratedPrefabs();
        if(prefab == null)
        {
            Debug.LogError("Prefab to instantiate is not set!");
            return;
        }

        if(startPoint == null || endPoint == null)
        {
            Debug.LogError("Start or End point not set!");
            return;
        }

        //calculate direction and distance between start and end points
        Vector3 direction = (endPoint.position - startPoint.position).normalized;
        float distance = Vector3.Distance(startPoint.position, endPoint.position);

        //Instantiate the Prefabs
        for (int i=0; i< numberOfPrefabs; i++)
        {
            Vector3 prefabPos = startPoint.TransformPoint(direction * (distance * i / (numberOfPrefabs - 1)));

            GameObject prefabObject = Instantiate(prefab, prefabPos, Quaternion.identity);
            prefabObject.transform.parent = startPoint;
            prefabList.Add(prefabObject);
        }
    }

    private void ClearGeneratedPrefabs()
    {
        foreach(GameObject pref in prefabList)
        {
            DestroyImmediate(pref);
        }
        prefabList.Clear();
    }

    private void OnValidate()
    {
        numberOfPrefabs = Mathf.Max(2, numberOfPrefabs);
    }
}
