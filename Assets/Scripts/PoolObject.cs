using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject{

    int ObjectCount;
    public List<GameObject> Objects;
    string PoolName;
    GameObject prefab;

    public PoolObject(GameObject Prefab,string Name, int Count = 10 ) 
    {
        ObjectCount = Count;
        prefab = Prefab;
        PoolName = Name;
        Objects = new List<GameObject>();
        CreatePool();
    }

    private void CreatePool()
    {
        for(int i = 0; i < ObjectCount; i++)
        {
            GameObject go = GameObject.Instantiate(prefab);
            Objects.Add(go);
            go.name = PoolName + i;
            go.SetActive(false);
        }
    }

    private GameObject FindAvailableObject()
    {
        for(int i =0; i< Objects.Count; i++)
        {
            if (!Objects[i].activeInHierarchy)
            {
                return Objects[i];
            }
            
        }
        return null;
    }

    public GameObject RequestObject()
    {
        Debug.Log("requesting object");
        GameObject go = FindAvailableObject();
        go.SetActive(true);
        return go;
    }




}
