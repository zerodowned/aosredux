/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class minifloralrugAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new minifloralrugAddonDeed();
			}
		}

		[ Constructable ]
		public minifloralrugAddon()
		{
			AddComponent( new AddonComponent( 2800 ), -1, 1, 0 );
			AddComponent( new AddonComponent( 2805 ), 0, 1, 0 );
			AddComponent( new AddonComponent( 2798 ), 1, 1, 0 );
			AddComponent( new AddonComponent( 2799 ), -1, -1, 0 );
			AddComponent( new AddonComponent( 2803 ), 0, -1, 0 );
			AddComponent( new AddonComponent( 2796 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 2804 ), 1, 0, 0 );
			AddComponent( new AddonComponent( 2801 ), 1, -1, 0 );
			AddComponent( new AddonComponent( 2802 ), -1, 0, 0 );
			AddonComponent ac = null;
			ac = new AddonComponent( 2799 );
			AddComponent( ac, -1, -1, 0 );
			ac = new AddonComponent( 2802 );
			AddComponent( ac, -1, 0, 0 );
			ac = new AddonComponent( 2803 );
			AddComponent( ac, 0, -1, 0 );
			ac = new AddonComponent( 2796 );
			AddComponent( ac, 0, 0, 0 );

		}

		public minifloralrugAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class minifloralrugAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new minifloralrugAddon();
			}
		}

		[Constructable]
		public minifloralrugAddonDeed()
		{
			Name = "mini floral rug";
		}

		public minifloralrugAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}