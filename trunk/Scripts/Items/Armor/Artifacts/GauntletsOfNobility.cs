using System;
using Server;

namespace Server.Items
{
	public class GauntletsOfNobility : RingmailGloves
	{
		public override int LabelNumber{ get{ return 1061092; } } // Gauntlets of Nobility
		public override int ArtifactRarity{ get{ return 11; } }

		public override int BasePhysicalResistance{ get{ return 18; } }
		public override int BasePoisonResistance{ get{ return 20; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public GauntletsOfNobility()
		{
			Hue = 0x3E7;
			Attributes.BonusStr = 8;
			Attributes.Luck = 100;
			Attributes.WeaponDamage = 20;
		}

		public GauntletsOfNobility( Serial serial ) : base( serial )
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
			{
				if ( Hue == 0x562 )
					Hue = 0x4FE;

				PhysicalBonus = 0;
				PoisonBonus = 0;
			}
		}
	}
}