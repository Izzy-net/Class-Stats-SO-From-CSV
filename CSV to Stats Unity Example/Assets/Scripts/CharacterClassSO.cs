using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterClassSO", menuName = "Stats/NewCharacterClassSO", order = 0)]
public class CharacterClassSO : CSVPopulableClassSO
{
    [SerializeField] float[] health;
    [SerializeField] float[] experienceFromDeath;
    [SerializeField] float[] experienceToLevel;
    [SerializeField] float[] damage;

    public override string ClassKey => this.name;

    public float GetHealth(int level)
    {
        if (health.Length < level) return health[health.Length - 1];
        return health[(level - 1)];
    }

    public float GetExperienceFromDeath(int level)
    {
        if (experienceFromDeath.Length < level) return experienceFromDeath[(experienceFromDeath.Length - 1)]; 
        return experienceFromDeath[(level - 1)];
    }

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

    public float GetDamage(int level)
    {
        if (damage.Length < level) return damage[damage.Length - 1];
        return damage[level - 1];
    }

    protected override void PopulateData(Dictionary<string, Dictionary<string, float[]>> dictionary)
    {
        Debug.Log("CSVKey: " + ClassKey);
        var data = dictionary[ClassKey];
        if (data.ContainsKey("Base Health"))        //WARNING: string reference to stat name in Progression Stats spreadsheet
        {
            health = data["Base Health"];
        }

        if (data.ContainsKey("Experience gained"))
        {
            experienceFromDeath = data["Experience gained"];
        }

        if (data.ContainsKey("Cumulative Experience"))
        {
            experienceToLevel = data["Cumulative Experience"];
        }

        if (data.ContainsKey("Base Damage (per hit)"))
        {
            damage = data["Base Damage (per hit)"];
        }
    }
}
