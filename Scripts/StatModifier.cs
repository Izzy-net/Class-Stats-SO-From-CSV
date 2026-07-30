[System.Serializable]
public class StatModifer
{
    public ModifierMethod modifierMethod;
    public float statModifier = 0f;
}

public enum ModifierMethod
{
    None,
    multiply,
    add,
    divide,
    subtract
}