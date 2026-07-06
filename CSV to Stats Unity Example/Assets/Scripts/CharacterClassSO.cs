using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

[CreateAssetMenu(fileName = "CharacterClassSO", menuName = "Stats/NewCharacterClassSO", order = 0)]
public class CharacterClassSO : CSVPopulableClassSO
{
    [SerializeField] float[] health;
    [SerializeField] float[] damage;

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
        data = dictionary[ClassKey];
        
        if (data.ContainsKey("Base Health"))        //WARNING: string reference to stat name in Progression Stats spreadsheet
        {
            health = data["Base Health"];
        }

        if (data.ContainsKey("Base Damage"))
        {
            damage = data["Base Damage"];
        }        
    }
}
