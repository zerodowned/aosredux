using System;
using Server;

namespace Server.Items
{
	public class TheDragonSlayer : Lance
	{
		public override int LabelNumber{ get{ return 1061248; } } // The Dragon Slayer
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public TheDragonSlayer()
		{
			Hue = 0x3E7;
			Slayer = SlayerName.DragonSlaying;
			Attributes.Luck = 110;
			Attributes.WeaponDamage = 50;
			WeaponAttributes.ResistFireBonus = 20;
			WeaponAttributes.UseBestSkill = 1;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = chaos = direct = 0;
			nrgy = 100;
		}

		public TheDragonSlayer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Slayer == SlayerName.None )
				Slayer = SlayerName.DragonSlaying;
		}
	}
}