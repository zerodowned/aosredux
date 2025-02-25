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
	public class largecarpetwestAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new largecarpetwestAddonDeed();
			}
		}

		[ Constructable ]
		public largecarpetwestAddon()
		{
			AddComponent( new AddonComponent( 2750 ), -1, -1, 0 );
			AddComponent( new AddonComponent( 2750 ), -1, 0, 0 );
			AddComponent( new AddonComponent( 2750 ), -1, 1, 0 );
			AddComponent( new AddonComponent( 2809 ), -1, 2, 0 );
			AddComponent( new AddonComponent( 2750 ), 1, 1, 0 );
			AddComponent( new AddonComponent( 2807 ), 0, -2, 0 );
			AddComponent( new AddonComponent( 2750 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 2751 ), 0, -1, 0 );
			AddComponent( new AddonComponent( 2751 ), 2, -1, 0 );
			AddComponent( new AddonComponent( 2809 ), 2, 2, 0 );
			AddComponent( new AddonComponent( 2751 ), 2, 1, 0 );
			AddComponent( new AddonComponent( 2806 ), -3, 1, 0 );
			AddComponent( new AddonComponent( 2756 ), -3, 2, 0 );
			AddComponent( new AddonComponent( 2809 ), -2, 2, 0 );
			AddComponent( new AddonComponent( 2751 ), -2, 1, 0 );
			AddComponent( new AddonComponent( 2809 ), 0, 2, 0 );
			AddComponent( new AddonComponent( 2755 ), -3, -2, 0 );
			AddComponent( new AddonComponent( 2807 ), -2, -2, 0 );
			AddComponent( new AddonComponent( 2807 ), -1, -2, 0 );
			AddComponent( new AddonComponent( 2757 ), 3, -2, 0 );
			AddComponent( new AddonComponent( 2808 ), 3, -1, 0 );
			AddComponent( new AddonComponent( 2809 ), 1, 2, 0 );
			AddComponent( new AddonComponent( 2750 ), 1, -1, 0 );
			AddComponent( new AddonComponent( 2807 ), 2, -2, 0 );
			AddComponent( new AddonComponent( 2750 ), -2, 0, 0 );
			AddComponent( new AddonComponent( 2751 ), -2, -1, 0 );
			AddComponent( new AddonComponent( 2806 ), -3, -1, 0 );
			AddComponent( new AddonComponent( 2806 ), -3, 0, 0 );
			AddComponent( new AddonComponent( 2750 ), 2, 0, 0 );
			AddComponent( new AddonComponent( 2751 ), 0, 1, 0 );
			AddComponent( new AddonComponent( 2807 ), 1, -2, 0 );
			AddComponent( new AddonComponent( 2750 ), 1, 0, 0 );
			AddComponent( new AddonComponent( 2808 ), 3, 0, 0 );
			AddComponent( new AddonComponent( 2808 ), 3, 1, 0 );
			AddComponent( new AddonComponent( 2754 ), 3, 2, 0 );
			AddonComponent ac = null;
			ac = new AddonComponent( 2755 );
			AddComponent( ac, -3, -2, 0 );
			ac = new AddonComponent( 2806 );
			AddComponent( ac, -3, -1, 0 );
			ac = new AddonComponent( 2806 );
			AddComponent( ac, -3, 0, 0 );
			ac = new AddonComponent( 2806 );
			AddComponent( ac, -3, 1, 0 );
			ac = new AddonComponent( 2807 );
			AddComponent( ac, -2, -2, 0 );
			ac = new AddonComponent( 2807 );
			AddComponent( ac, -1, -2, 0 );
			ac = new AddonComponent( 2807 );
			AddComponent( ac, 0, -2, 0 );
			ac = new AddonComponent( 2807 );
			AddComponent( ac, 1, -2, 0 );
			ac = new AddonComponent( 2807 );
			AddComponent( ac, 2, -2, 0 );
			ac = new AddonComponent( 2751 );
			AddComponent( ac, -2, -1, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, -2, 0, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, -1, 0, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, 1, 0, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, 2, 0, 0 );
			ac = new AddonComponent( 2751 );
			AddComponent( ac, -2, 1, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, -1, -1, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, -1, 1, 0 );
			ac = new AddonComponent( 2751 );
			AddComponent( ac, 0, -1, 0 );
			ac = new AddonComponent( 2751 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, 1, -1, 0 );
			ac = new AddonComponent( 2750 );
			AddComponent( ac, 1, 1, 0 );
			ac = new AddonComponent( 2751 );
			AddComponent( ac, 2, -1, 0 );
			ac = new AddonComponent( 2751 );
			AddComponent( ac, 2, 1, 0 );

		}

		public largecarpetwestAddon( Serial serial ) : base( serial )
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

	public class largecarpetwestAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new largecarpetwestAddon();
			}
		}

		[Constructable]
		public largecarpetwestAddonDeed()
		{
			Name = "large carpet west";
		}

		public largecarpetwestAddonDeed( Serial serial ) : base( serial )
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