using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pooled Object", menuName = "Data/Pool Data")]
public class PoolingObjectData : ScriptableObject
{
	public string tag;
	public GameObject prefab;
	public int size;
}

