using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
public abstract class CSVPopulableClassSO : ScriptableObject 
{
    [SerializeField] private TextAsset CSVFile;

    public abstract string ClassKey { get; } //defined here to force implementation in child

    public void PopulateFromCSV()
    {
        CSVClassReader.ReadFile(CSVFile);  //reads file and sorts it into dictionary
        PopulateData(CSVClassReader.GetDictionary());  
    }

    public void Modify()
    {
        ModifyData();
        ResetModifiers(); //reset values so modifications aren't accidentally re-applied
    }

    protected abstract void PopulateData(Dictionary<string, Dictionary<string, float[]>> dictionary);
    protected abstract void ModifyData();
    protected abstract void ResetModifiers();
}
#endif