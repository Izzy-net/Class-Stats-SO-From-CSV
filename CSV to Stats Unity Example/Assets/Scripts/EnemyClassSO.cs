using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyClassSO", menuName = "Stats/NewEnemyClassSO", order = 2)]
public class EnemyClassSO : CharacterClassSO
{
    [SerializeField] float[] experienceFromDeath;
    
    public float GetExperienceFromDeath(int level)
    {
        if (experienceFromDeath.Length < level) return experienceFromDeath[(experienceFromDeath.Length - 1)]; 
        return experienceFromDeath[(level - 1)];
    }

    protected override void PopulateData(Dictionary<string, Dictionary<string, float[]>> dictionary)
    {
        base.PopulateData(dictionary);

        if (data.ContainsKey("Experience From Death"))
        {
            experienceFromDeath = data["Experience From Death"];
        }
    }
}