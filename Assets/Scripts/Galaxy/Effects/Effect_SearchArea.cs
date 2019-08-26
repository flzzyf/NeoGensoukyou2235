using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Effect/SearchArea")]
public class Effect_SearchArea : Effect
{
    public Vector2 offset;

    public float radius;

    public Effect effect;

    public Filter filter;

    public override void Trigger()
    {
        Vector2 newOffset = offset;
        newOffset.x *= caster.transform.localScale.x;
        Vector2 searchPos = (Vector2)caster.transform.position + newOffset;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(searchPos, radius);

		//遍历判断每一个目标
		//for (int i = 0; i < colliders.Length; i++)
		//{
		//	Actor a = colliders[i].GetComponent<Actor>();
		//	Debug.Log(a.gameObject.name);

		//	//判断目标过滤器
		//	//如果目标类型为敌人，且敌对，则继续，否则结束
		//	if (filter.IsAvailableTarget(caster, a))
		//	{

		//	}
		//	else
		//		continue;

		//	//触发效果
		//	effect.Trigger(caster, a);
		//}
	}
}
