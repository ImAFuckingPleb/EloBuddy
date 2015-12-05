﻿using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using EloBuddy.SDK.Enumerations;
using Settings = NinjaNunu.Config.Modes.Combo;

namespace NinjaNunu.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {


            if (ChannelingR())  //WujuSan
            {
                var TargetR = TargetSelector.GetTarget(R.Range, DamageType.Magical);
                if (!EntityManager.Heroes.Enemies.Any(it => it.IsValidTarget(575))) //Considering that when you started to cast R there was MinR enemies in your range
                {
                    //for ensure that Nunu will cancel his ult, you need to make Nunu move

                    Orbwalker.DisableMovement = false;
                    EloBuddy.Player.IssueOrder(GameObjectOrder.MoveTo, TargetR);
                    Orbwalker.DisableAttacking = false;
                }
            }

            if (Settings.UseR && R.IsReady())
            {
                if (EntityManager.Heroes.Enemies.Count(h => h.IsValidTarget(325)) >= Settings.MinR)
                {
                    Orbwalker.DisableAttacking = true;
                    Orbwalker.DisableMovement = true;
                    R.Cast();
                    return;
                }

            }

            if (Settings.UseE && E.IsReady() && !ChannelingR())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);
                if (target != null)
                {
                    E.Cast(target);
                    return;
                }
            }

            if (Settings.UseW && W.IsReady() && !ChannelingR() && Player.Instance.ManaPercent >= Settings.ManaW)
            {
                var ally = EntityManager.Heroes.Allies.OrderByDescending(a => a.TotalAttackDamage).FirstOrDefault(b => b.Distance(Player.Instance) < 700);
                if (ally != null && Player.Instance.CountEnemiesInRange(1000) > 0)
                {
                    W.Cast(ally);
                    return;
                }
                if (Settings.UseW && W.IsReady() && Player.Instance.CountEnemiesInRange(1000) > 0)
                {
                    W.Cast(Player.Instance);
                    return;
                }       
            }
        }
    }
}
