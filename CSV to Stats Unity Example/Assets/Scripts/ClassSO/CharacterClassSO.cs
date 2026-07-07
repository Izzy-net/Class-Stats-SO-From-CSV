using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterClassSO", menuName = "Stats/NewCharacterClassSO", order = 0)]
public class CharacterClassSO : CSVPopulableClassSO
{
    [SerializeField] string classKeyOverride;
    [SerializeField] float[] health;
    [SerializeField] StatModifer healthStatModifier;

    [SerializeField] float[] damage;
    [SerializeField] StatModifer damageStatModifier;

    public override string ClassKey => this.name;

    protected Dictionary<string, float[]> data = new Dictionary<string, float[]>();

    public float GetHealth(int level)
    {
        if (health.Length < level) return health[health.Length - 1];
        return health[(level - 1)];
    }

    public float GetDamage(int level)
    {
        if (damage.Length < level) return damage[damage.Length - 1];
        return damage[level - 1];
    }

    protected override void PopulateData(Dictionary<string, Dictionary<string, float[]>> dictionary)
    {
        string classKey;
        classKey = classKeyOverride.Length > 0 ? classKeyOverride : ClassKey;
        data = dictionary[classKey];
        
        if (data.ContainsKey("Base Health"))        //WARNING: string reference to stat name in Progression Stats spreadsheet
        {
            health = data["Base Health"];
        }

        if (data.ContainsKey("Base Damage"))
        {
            damage = data["Base Damage"];
        }        
    }

    protected override void ModifyData()
    {
        if (healthStatModifier.modifierMethod != ModifierMethod.None)
        {
            ModifyField(health, healthStatModifier);
        }

        if (damageStatModifier.modifierMethod != ModifierMethod.None)
        {
            ModifyField(damage, damageStatModifier);
        }
    }

    protected override void ResetModifiers()  // add statModifier = default for any new stat modifiers you add
    {
        healthStatModifier = default;
        damageStatModifier = default;
    }

    protected void ModifyField(float[] field, StatModifer modifier)
    {
        switch (modifier.modifierMethod)
        {
            case ModifierMethod.multiply:
                for (int i = 0; i < field.Length; i++)
                {
                    field[i] *= modifier.statModifier;
                }
                break;
            case ModifierMethod.add:
                for (int i = 0; i < field.Length; i++)
                {
                    field[i] += modifier.statModifier;
                }
                break;
            case ModifierMethod.divide:
                for (int i = 0; i < field.Length; i++)
                {
                    field[i] /= modifier.statModifier;
                }
                break;
            case ModifierMethod.subtract:
                for (int i = 0; i < field.Length; i++)
                {
                    field[i] -= modifier.statModifier;
                }
                break;
            default:
                return;
        }
    }
}
