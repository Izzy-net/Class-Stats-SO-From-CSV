using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerClassSO", menuName = "Stats/NewPlayerClassSO", order = 1)]
public class PlayerClassSO : CharacterClassSO
{
    [SerializeField] float[] experienceToLevel;
    [SerializeField] StatModifer experienceStatModifier;
    
    public int GetExperienceToLevel(float experience)
    {
        for (int i = 0; i < experienceToLevel.Length; i++)
        {
            if (experience < experienceToLevel[i]) //here experienceToLevel[i] will reflect the level not yet reached
            {
                return i;   //because experienceToLevel is an array where level 1 is at index 0, returning i will return the correct level
            }               //where the level not yet reached at experienceToLevel[i] will be index i but the level would be i+1 as there
                            //is no level 0 ::: experienceToLevel[i] where i=0 is level 1, i=1 is level 2 etc.
            else if (experience == experienceToLevel[i])
            {
                return i + 1;
            }
        }
        return experienceToLevel.Length + 1;
    }

    protected override void PopulateData(Dictionary<string, Dictionary<string, float[]>> dictionary)
    {
        base.PopulateData(dictionary);

        if (data.ContainsKey("Experience To Level"))
        {
            experienceToLevel = data["Experience To Level"];
        }
    }

    protected override void ModifyData()
    {
        base.ModifyData();

        if (experienceStatModifier.modifierMethod != ModifierMethod.None)
        {
            ModifyField(experienceToLevel, experienceStatModifier);
        }
    }

    protected override void ResetModifiers()  // add statModifier = default for any new stat modifiers you add
    {
        base.ResetModifiers();

        experienceStatModifier = default;
    }
}