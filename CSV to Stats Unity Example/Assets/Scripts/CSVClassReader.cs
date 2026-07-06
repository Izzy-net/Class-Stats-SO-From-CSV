using UnityEngine;
using System.Collections.Generic;

public class CSVClassReader
{
    private static TextAsset currentCSVTextAsset;
    private static Dictionary<string, Dictionary<string, float[]>> classes;

    public static void ReadFile(TextAsset textAsset)
    {
        currentCSVTextAsset = textAsset;

        if (ValidCSV())
        {
            ReadFileIntoDict();   
        }
    }

    public static Dictionary<string, Dictionary<string, float[]>> GetDictionary()
    {
        return classes;
    }

    private static bool ValidCSV()
    {
        if (currentCSVTextAsset == null) 
        {
            Debug.LogError("Empty CSV Supplied");
            return false;
        }
        return true;
    }

    private static void ReadFileIntoDict()
    {
        classes = new Dictionary<string, Dictionary<string, float[]>>();
        var statType = new Dictionary<string, float[]>();

        string[] rows = currentCSVTextAsset.text.Split("\n");   //divide full document into rows
        string currentClass = null;
        string[] firstRow = rows[0].Split(","); //WARNING: because of how the document is set out
        int levels = FindValidLevels(firstRow);

        for (int i = 2; i < rows.Length; i++) //WARNING: starting at row 2 because of how the document is set out
        {
            string[] currentRow = rows[i].Split(",");    //split row into cells
            if (currentRow[0].Length < 1) continue;      //if the class designation is blank, skip this row 

            if (currentRow[0].Length > 1 && !classes.ContainsKey(currentRow[0]))    //if this row has a new class name
            {
                if (statType.Count > 0)             //if the stats of the currentClass (class from previous row/s) are populated 
                {
                    classes[currentClass] = statType;   //add stats for currentClass to classes
                    statType = new Dictionary<string, float[]>();  //initialise a new statType dictionary for the new class
                }
                currentClass = currentRow[0];       //set current class to new class
                classes[currentClass] = null;      //adds new currentClass to classes as a key
            }

            float[] values = new float[levels];  //initialise array with length equal to the levels for which progression is supported
            int maxIndex = levels + 2;           //WARNING: maxIndex is the index of the final level in currentRow - this is dependent on spreadsheet layout
            for (int r = 2; r < maxIndex; r++)   //WARNING: start at r=4 because level values start at the 5th column of the spreadsheet
            {
                if (float.TryParse(currentRow[r], out var value))
                {
                    values[r - 2] = value;       //r-4 will place the value in the right place in values (r-4=0 on the first loop)
                }
                else
                {
                    Debug.LogError("Invalid Stat Entry For: " + currentClass + "  in stat key: " + currentRow[1] + "  value " + r);
                }
            }
            statType[currentRow[1]] = values;
        }
        classes[currentClass] = statType; //adds the statType dictionary to classes for the last class after loop exits
    }

    private static int FindValidLevels(string[] row)  //find number of levels for progression so it remains consistent
    {                                                 //change if levels aren't the same for enemies vs player etc
        int levels = 0;
        for (int i = 2; i < row.Length; i++)          //WARNING: dependent on spreadsheet layout
        {
            if (int.TryParse(row[i], out int result))
            {
                levels += 1;
            }
        }
        Debug.Log(levels);
        return levels;
    }
}
