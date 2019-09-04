using UnityEngine;

public enum EffectTargetType { Null, Caster, Target, TargetPoint}

public class Effect : ScriptableObject
{
    [HideInInspector] public Unit caster;
    [HideInInspector] public Unit target;

	public EffectTargetType targetType;

	public virtual void Trigger()
    {

    }

    public void Trigger(Effect parent)
    {
        caster = parent.caster;
        target = parent.target;

        Trigger();
    }

    public virtual void Trigger(Unit caster, Unit target)
    {
        this.caster = caster;
        this.target = target;

        Trigger();
    }

	public virtual void Trigger(Unit caster)
	{
		this.caster = caster;

		Trigger();
	}
}
