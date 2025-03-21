using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.Stats
{
    [Version(0, 1, 1)]
    
    [Title("Add Status Effect")]
    [Category("Stats/Add Status Effect")]
    
    [Image(typeof(IconStatusEffect), ColorTheme.Type.Green, typeof(OverlayPlus))]
    [Description("Adds a Status Effect to the selected game object's Traits component")]

    [Parameter("Target", "The targeted game object with a Traits component")]
    [Parameter("Status Effect", "The type of Status Effect that is added")]
    
    [Keywords("Buff", "Debuff", "Enhance", "Ailment")]
    [Keywords(
        "Blind", "Dark", "Burn", "Confuse", "Dizzy", "Stagger", "Fear", "Freeze", "Paralyze", 
        "Shock", "Silence", "Sleep", "Silence", "Slow", "Toad", "Weak", "Strong", "Poison"
    )]
    [Keywords(
        "Haste", "Protect", "Reflect", "Regenerate", "Shell", "Armor", "Shield", "Berserk",
        "Focus", "Raise"
    )]

    [Serializable]
    public class InstructionStatsAddStatusEffect : Instruction
    {
        [SerializeField]
        private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

        [SerializeField]
        private PropertyGetStatusEffect m_StatusEffect = new PropertyGetStatusEffect();

        public override string Title => $"Add {this.m_StatusEffect} to {this.m_Target}";
        
        protected override Task Run(Args args)
        {
            GameObject target = this.m_Target.Get(args);
            if (target == null) return DefaultResult;

            Traits traits = target.Get<Traits>();
            if (traits == null) return DefaultResult;

            StatusEffect statusEffect = this.m_StatusEffect.Get(args);
            if (statusEffect == null) return DefaultResult;
            
            traits.RuntimeStatusEffects.Add(statusEffect);
            return DefaultResult;
        }
    }
}