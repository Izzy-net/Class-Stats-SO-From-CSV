using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EnemyClassSO", menuName = "Stats/NewEnemyClassSO", order = 2)]
public class EnemyClassSO : CharacterClassSO
{
    [SerializeField] float[] experienceFromDeath;
    [SerializeField] StatModifer experienceStatModifier;
    
    public float GetExperienceFromDeath(int level)
    {
        if (experienceFromDeath.Length < level) return experienceFromDeath[(experienceFromDeath.Length - 1)]; 
        return experienceFromDeath[(level - 1)];
    }

    protected override void PopulateData(Dictionary<string, Dictionary<string, float[]>> dictionary)
    {
        base.PopulateData(dictionary);

        if (data.ContainsKey(ClassStatConsts.Enemies.EXP_FROM_DEATH))
        {
            experienceFromDeath = data[ClassStatConsts.Enemies.EXP_FROM_DEATH];
        }
    }

    protected override void ModifyData()
    {
        base.ModifyData();

        if (experienceStatModifier.modifierMethod != ModifierMethod.None)
        {
            ModifyField(experienceFromDeath, experienceStatModifier);
        }
    }

    protected override void ResetModifiers()  // add statModifier = default for any new stat modifiers you add
    {
        base.ResetModifiers();

        experienceStatModifier = default;
    }
}