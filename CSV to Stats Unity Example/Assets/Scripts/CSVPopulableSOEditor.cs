using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CSVPopulableClassSO), true)]      //this specifies which script we are customing the editor for and true to affect children as well
public class CSVPopulableSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); //we only want to add a button so we want the inspector to be drawn as normal first

        CSVPopulableClassSO myPopulableClassSO = (CSVPopulableClassSO)target; 

        if (GUILayout.Button("Populate From File"))     //create button
        {
            Debug.Log("populate");
            myPopulableClassSO.PopulateFromCSV();   //method to run on target when button is pressed
        }
    }
}
//See tutorial :: https://learn.unity.com/tutorial/editor-scripting#5c7f8528edbc2a002053b5f7