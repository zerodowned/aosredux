using System;

namespace Server.Items
{
	public class PendantOfTheMagi : GoldNecklace
	{
		public override int LabelNumber{ get{ return 1072937; } } // Pendant of the Magi

		[Constructable]
		public PendantOfTheMagi()
		{
			Hue = 0x48D;
			Attributes.BonusInt = 10;
			Attributes.RegenMana = 2;	
			Attributes.LowerRegCost = 30;
		}

		public PendantOfTheMagi( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
