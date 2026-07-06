using UnityEngine;
using System.Collections.Generic;
using System.IO;

#if UNITY_EDITOR
public abstract class CSVPopulableClassSO : ScriptableObject 
{
    [SerializeField] private TextAsset CSVFile;

    public abstract string ClassKey { get; } //defined here to force implementation in child

    public void PopulateFromCSV()
    {
        CSVClassReader.ReadFile(CSVFile);    //see below note for making this more general 
        PopulateData(CSVClassReader.GetDictionary());
    }

    public void Modify()
    {
        
    }

    protected abstract void PopulateData(Dictionary<string, Dictionary<string, float[]>> dictionary);
}
#endif