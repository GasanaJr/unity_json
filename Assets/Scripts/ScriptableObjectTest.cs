using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Object Test", menuName = "My Scriptable/Object/Custom", order =100)]
public class ScriptableObjectTest : ScriptableObject
{
    public string objName;
    public float objHealth;
    public Texture2D  texture;

}
