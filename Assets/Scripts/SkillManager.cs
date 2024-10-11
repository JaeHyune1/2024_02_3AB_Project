using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Player TargetPlayer;
    public Enemy TargetEnemy;

    public List<ISkillTarget> targets = new List<ISkillTarget>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            var fireball = new Skill<ISkillTarget, DamageEffect>("Fireball", new DamageEffect(20));
            fireball.Use(TargetEnemy);
        }
        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            var healSpell = new Skill<Player, HealEffect>("Heal", new HealEffect(20));
            healSpell.Use(TargetPlayer);
        }
        if(Input.GetKeyUp(KeyCode.Alpha3))
        {
            var multiTargetSkill = new Skill<ISkillTarget, DamageEffect>("AOE Attack", new DamageEffect(10));
            foreach(var target in targets)
            {
                multiTargetSkill.Use(target);
            }
        }
    }
}
