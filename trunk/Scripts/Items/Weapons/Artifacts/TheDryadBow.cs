using System;
using Server;

namespace Server.Items
{
	public class TheDryadBow : Bow
	{
		public override int LabelNumber{ get{ return 1061090; } } // The Dryad Bow
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public TheDryadBow()
		{
			ItemID = 0x13B1;
			Hue = 0x3E7;
			SkillBonuses.SetValues( 0, m_PossibleBonusSkills[Utility.Random(m_PossibleBonusSkills.Length)], (Utility.Random( 4 ) == 0 ? 10.0 : 5.0) );
			WeaponAttributes.SelfRepair = 5;
			Attributes.WeaponSpeed = 50;
			Attributes.WeaponDamage = 35;
			WeaponAttributes.ResistPoisonBonus = 15;
		}

		private static SkillName[] m_PossibleBonusSkills = new SkillName[]
			{
				SkillName.Archery,
				SkillName.Healing,
				SkillName.MagicResist,
				SkillName.Peacemaking,
				SkillName.Chivalry,
			};

		public TheDryadBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 )
				SkillBonuses.SetValues( 0, m_PossibleBonusSkills[Utility.Random(m_PossibleBonusSkills.Length)], (Utility.Random( 4 ) == 0 ? 10.0 : 5.0) );
		}
	}
}
