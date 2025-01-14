using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefAlchemy : CraftSystem
	{
		public override SkillName MainSkill
		{
			get { return SkillName.Alchemy; }
		}

		public override int GumpTitleNumber
		{
			get { return 1044001; } // <CENTER>ALCHEMY MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if (m_CraftSystem == null)
					m_CraftSystem = new DefAlchemy();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin(CraftItem item)
		{
			return 0.0; // 0%
		}

		private DefAlchemy()
			: base(1, 1, 1.25)// base( 1, 1, 3.1 )
		{
		}

		public override int CanCraft(Mobile from, BaseTool tool, Type itemType)
		{
			if (tool == null || tool.Deleted || tool.UsesRemaining < 0)
				return 1044038; // You have worn out your tool!
			else if (!BaseTool.CheckAccessible(tool, from))
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect(Mobile from)
		{
			from.PlaySound(0x242);
		}

		private static Type typeofPotion = typeof(BasePotion);

		public static bool IsPotion(Type type)
		{
			return typeofPotion.IsAssignableFrom(type);
		}

		public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
				from.SendLocalizedMessage(1044038); // You have worn out your tool

			if (failed)
			{
				if (IsPotion(item.ItemType))
				{
					from.AddToBackpack(new Bottle());
					return 500287; // You fail to create a useful potion.
				}
				else
				{
					return 1044043; // You failed to create the item, and some of your materials are lost.
				}
			}
			else
			{
				from.PlaySound(0x240); // Sound of a filling bottle

				if (IsPotion(item.ItemType))
				{
					if (quality == -1)
						return 1048136; // You create the potion and pour it into a keg.
					else
						return 500279; // You pour the potion into a bottle...
				}
				else
				{
					return 1044154; // You create the item.
				}
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			// Refresh Potion
			index = AddCraft(typeof(RefreshPotion), 1044530, 1044538, -25, 25.0, typeof(BlackPearl), 1044353, 1, 1044361);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(TotalRefreshPotion), 1044530, 1044539, 25.0, 75.0, typeof(BlackPearl), 1044353, 5, 1044361);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			// Agility Potion
			index = AddCraft(typeof(AgilityPotion), 1044531, 1044540, 15.0, 65.0, typeof(Bloodmoss), 1044354, 1, 1044362);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(GreaterAgilityPotion), 1044531, 1044541, 35.0, 85.0, typeof(Bloodmoss), 1044354, 3, 1044362);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(NGreaterAgilityPotion), 1044531, "potężna mikstura zręcznośći" , 70.0, 100.0, typeof(GreaterAgilityPotion), 1044541, 10, "Nie masz wystarczającej ilości dużych mikstur zręczności");
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			AddByproduct(index, typeof(Bottle), 10);

			// Nightsight Potion
			index = AddCraft(typeof(NightSightPotion), 1044532, 1044542, -25.0, 25.0, typeof(SpidersSilk), 1044360, 1, 1044368);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			// Heal Potion
			index = AddCraft(typeof(LesserHealPotion), 1044533, 1044543, -25.0, 25.0, typeof(Ginseng), 1044356, 1, 1044364);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(HealPotion), 1044533, 1044544, 15.0, 65.0, typeof(Ginseng), 1044356, 3, 1044364);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(GreaterHealPotion), 1044533, 1044545, 55.0, 105.0, typeof(Ginseng), 1044356, 7, 1044364);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			// Strength Potion
			index = AddCraft(typeof(StrengthPotion), 1044534, 1044546, 25.0, 75.0, typeof(MandrakeRoot), 1044357, 2, 1044365);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(GreaterStrengthPotion), 1044534, 1044547, 45.0, 95.0, typeof(MandrakeRoot), 1044357, 5, 1044365);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(NGreaterStrengthPotion), 1044534, "potężna mikstura siły" , 70.0, 100.0, typeof(GreaterStrengthPotion), 1044547, 10, "Nie masz wystarczającej ilości dużych mikstur siły");
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			AddByproduct(index, typeof(Bottle), 10);

			// Poison Potion
			index = AddCraft(typeof(LesserPoisonPotion), 1044535, 1044548, -5.0, 45.0, typeof(Nightshade), 1044358, 1, 1044366);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(PoisonPotion), 1044535, 1044549, 15.0, 65.0, typeof(Nightshade), 1044358, 2, 1044366);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(GreaterPoisonPotion), 1044535, 1044550, 55.0, 105.0, typeof(Nightshade), 1044358, 4, 1044366);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(DeadlyPoisonPotion), 1044535, 1044551, 90.0, 140.0, typeof(Nightshade), 1044358, 8, 1044366);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			// Cure Potion
			index = AddCraft(typeof(LesserCurePotion), 1044536, 1044552, -10.0, 40.0, typeof(Garlic), 1044355, 1, 1044363);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(CurePotion), 1044536, 1044553, 25.0, 75.0, typeof(Garlic), 1044355, 3, 1044363);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(GreaterCurePotion), 1044536, 1044554, 65.0, 115.0, typeof(Garlic), 1044355, 6, 1044363);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			// Explosion Potion
			index = AddCraft(typeof(LesserExplosionPotion), 1044537, 1044555, 5.0, 55.0, typeof(SulfurousAsh), 1044359, 3, 1044367);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(ExplosionPotion), 1044537, 1044556, 35.0, 85.0, typeof(SulfurousAsh), 1044359, 5, 1044367);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			index = AddCraft(typeof(GreaterExplosionPotion), 1044537, 1044557, 65.0, 115.0, typeof(SulfurousAsh), 1044359, 10, 1044367);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			if (Core.SE)
			{
				index = AddCraft(typeof(SmokeBomb), 1044537, 1030248, 90.0, 120.0, typeof(Eggs), 1044477, 1, 1044253);
				AddRes(index, typeof(Ginseng), 1044356, 3, 1044364);
				SetNeededExpansion(index, Expansion.SE);
			}

			index = AddCraft(typeof(ConflagrationPotion), 1044109, 1072096, 55.0, 105.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(GraveDust), 1023983, 5, 1042081);
			index = AddCraft(typeof(GreaterConflagrationPotion), 1044109, 1072099, 70.0, 120.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(GraveDust), 1023983, 10, 1042081);

			// Mask Of Death Potion
			index = AddCraft(typeof(MaskOfDeathPotion), 1044109, 1072101, 55.0, 105.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(DaemonBlood), 1023965, 5, 1042081);
			index = AddCraft(typeof(GreaterMaskOfDeathPotion), 1044109, 1072104, 85.0, 135.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(DaemonBlood), 1023965, 10, 1042081);
			// Potka niewidzialnosci
			index = AddCraft(typeof(InvisibilityPotion), 1044109, "mikstura niewidzialnosci" , 55.0, 105.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(DaemonBlood), 1023965, 15, 1042081);
			AddRes(index, typeof(Gold), "zloto" , 500, 1042081);
			AddRes(index, typeof(ZoogiFungus), "grzyby zoogi" , 50, 1042081);
			// Confusion Blast Potion
			index = AddCraft(typeof(ConfusionBlastPotion), 1044109, 1072106, 50.0, 100.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(PigIron), 1023978, 5, 1042081);
			index = AddCraft(typeof(GreaterConfusionBlastPotion), 1044109, 1072109, 65.0, 115.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(PigIron), 1023978, 10, 1042081);

			// Water Elemental Potion
			index = AddCraft(typeof(WaterElementalPotion), 1071088, 1071089, 95.0, 100.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(BatWing), 1023960, 5, 1042081);
			AddRes(index, typeof(BlackPearl), 1044353, 15, 1042081);

			// Fire Elemental Potion
			index = AddCraft(typeof(FireElementalPotion), 1071088, 1071090, 95.0, 100.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(NoxCrystal), 1023982, 5, 1042081);
			AddRes(index, typeof(SulfurousAsh), 1044359, 15, 1042081);

			// Earth Elemental Potion
			index = AddCraft(typeof(EarthElementalPotion), 1071088, 1071091, 95.0, 100.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(PigIron), 1023978, 5, 1042081);
			AddRes(index, typeof(MandrakeRoot), 1044357, 15, 1042081);

			/*
			// Invisibility Potion
			index = AddCraft(typeof(InvisibilityPotion), 1071088, 1071092, 95.0, 105.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(PowderOfTranslocation), 1029912, 5, 1042081);
			AddRes(index, typeof(ExecutionersCap), 1023971, 1, 1042081);

			// RevitalizePotion
			index = AddCraft(typeof(RevitalizePotion), 1071088, 1071093, 90.0, 105.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(Ginseng), 1044356, 25, 1042081);
			AddRes(index, typeof(BlackPearl), 1044353, 25, 1042081);
			AddRes(index, typeof(Garlic), 1044355, 25, 1042081);

			// SuperPotion
			index = AddCraft(typeof(SuperPotion), 1071088, 1071094, 95.0, 110.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(DaemonBone), 1017412, 20, 1042081);
			*/

			// PetResurrectPotion
			index = AddCraft(typeof(PetResurrectPotion), 1071088, 1071095, 95.0, 105.0, typeof(Bottle), 1044529, 1, 1044558);
			AddRes(index, typeof(Bandage), 1023617, 5, 1042081);
			AddRes(index, typeof(Bone), 1023966, 15, 1042081);
			AddRes(index, typeof(PowderOfTranslocation), 1029912, 1, 1042081);

            index = AddCraft(typeof(PlainTobaccoApple), 1071088, 1061202, 0.0, 0.0, typeof(PlainTobacco), 1061208, 1, 1061210);
            AddRes(index, typeof(Apple), 1044479, 1, 1061211);

            index = AddCraft(typeof(PlainTobaccoPear), 1071088, 1061203, 0.0, 0.0, typeof(PlainTobacco), 1061208, 1, 1061210);
            AddRes(index, typeof(Pear), 1044481, 1, 1061211);

            index = AddCraft(typeof(PlainTobaccoLemon), 1071088, 1061204, 0.0, 0.0, typeof(PlainTobacco), 1061208, 1, 1061210);
            AddRes(index, typeof(Lemon), 1025929, 1, 1061211);

            index = AddCraft(typeof(NobleTobaccoApple), 1071088, 1061205, 0.0, 0.0, typeof(NobleTobacco), 1061209, 1, 1061210);
            AddRes(index, typeof(Apple), 1044479, 1, 1061211);

            index = AddCraft(typeof(NobleTobaccoPear), 1071088, 1061206, 0.0, 0.0, typeof(NobleTobacco), 1061209, 1, 1061210);
            AddRes(index, typeof(Pear), 1044481, 1, 1061211);

            index = AddCraft(typeof(NobleTobaccoLemon), 1071088, 1061207, 0.0, 0.0, typeof(NobleTobacco), 1061209, 1, 1061210);
            AddRes(index, typeof(Lemon), 1025929, 1, 1061211);

        }
    }
}