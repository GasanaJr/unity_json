using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DataRetrieval : MonoBehaviour
{
    [SerializeField] private ScriptableObjectTest myObjTest;
    [SerializeField] private TMP_Text myObjText;
    [SerializeField] private RawImage myImage;

    public void GenerateText()
    {
        myObjText.text = myObjTest.objName;
        myImage.texture = myObjTest.texture;
    }
}
