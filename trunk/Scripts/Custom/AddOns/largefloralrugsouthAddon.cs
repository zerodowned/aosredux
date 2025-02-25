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
	public class largefloralrugsouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new largefloralrugsouthAddonDeed();
			}
		}

		[ Constructable ]
		public largefloralrugsouthAddon()
		{
			AddComponent( new AddonComponent( 2797 ), 1, 1, 0 );
			AddComponent( new AddonComponent( 2796 ), 1, 2, 0 );
			AddComponent( new AddonComponent( 2797 ), 1, -1, 0 );
			AddComponent( new AddonComponent( 2796 ), 1, 0, 0 );
			AddComponent( new AddonComponent( 2803 ), 1, -3, 0 );
			AddComponent( new AddonComponent( 2796 ), 1, -2, 0 );
			AddComponent( new AddonComponent( 2803 ), -1, -3, 0 );
			AddComponent( new AddonComponent( 2796 ), -1, -2, 0 );
			AddComponent( new AddonComponent( 2797 ), -1, -1, 0 );
			AddComponent( new AddonComponent( 2796 ), -1, 0, 0 );
			AddComponent( new AddonComponent( 2797 ), -1, 1, 0 );
			AddComponent( new AddonComponent( 2796 ), -1, 2, 0 );
			AddComponent( new AddonComponent( 2798 ), 2, 3, 0 );
			AddComponent( new AddonComponent( 2805 ), 1, 3, 0 );
			AddComponent( new AddonComponent( 2805 ), 0, 3, 0 );
			AddComponent( new AddonComponent( 2797 ), 0, 2, 0 );
			AddComponent( new AddonComponent( 2797 ), 0, 1, 0 );
			AddComponent( new AddonComponent( 2797 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 2797 ), 0, -1, 0 );
			AddComponent( new AddonComponent( 2797 ), 0, -2, 0 );
			AddComponent( new AddonComponent( 2803 ), 0, -3, 0 );
			AddComponent( new AddonComponent( 2804 ), 2, -2, 0 );
			AddComponent( new AddonComponent( 2801 ), 2, -3, 0 );
			AddComponent( new AddonComponent( 2802 ), -2, -2, 0 );
			AddComponent( new AddonComponent( 2799 ), -2, -3, 0 );
			AddComponent( new AddonComponent( 2802 ), -2, 0, 0 );
			AddComponent( new AddonComponent( 2802 ), -2, -1, 0 );
			AddComponent( new AddonComponent( 2802 ), -2, 2, 0 );
			AddComponent( new AddonComponent( 2802 ), -2, 1, 0 );
			AddComponent( new AddonComponent( 2805 ), -1, 3, 0 );
			AddComponent( new AddonComponent( 2800 ), -2, 3, 0 );
			AddComponent( new AddonComponent( 2804 ), 2, 0, 0 );
			AddComponent( new AddonComponent( 2804 ), 2, -1, 0 );
			AddComponent( new AddonComponent( 2804 ), 2, 2, 0 );
			AddComponent( new AddonComponent( 2804 ), 2, 1, 0 );
			AddonComponent ac = null;
			ac = new AddonComponent( 2799 );
			AddComponent( ac, -2, -3, 0 );
			ac = new AddonComponent( 2802 );
			AddComponent( ac, -2, -2, 0 );
			ac = new AddonComponent( 2802 );
			AddComponent( ac, -2, -1, 0 );
			ac = new AddonComponent( 2802 );
			AddComponent( ac, -2, 0, 0 );
			ac = new AddonComponent( 2802 );
			AddComponent( ac, -2, 1, 0 );
			ac = new AddonComponent( 2802 );
			AddComponent( ac, -2, 2, 0 );
			ac = new AddonComponent( 2800 );
			AddComponent( ac, -2, 3, 0 );
			ac = new AddonComponent( 2803 );
			AddComponent( ac, -1, -3, 0 );
			ac = new AddonComponent( 2796 );
			AddComponent( ac, -1, -2, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, -1, -1, 0 );
			ac = new AddonComponent( 2796 );
			AddComponent( ac, -1, 0, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, -1, 1, 0 );
			ac = new AddonComponent( 2796 );
			AddComponent( ac, -1, 2, 0 );
			ac = new AddonComponent( 2805 );
			AddComponent( ac, -1, 3, 0 );
			ac = new AddonComponent( 2803 );
			AddComponent( ac, 0, -3, 0 );
			ac = new AddonComponent( 2803 );
			AddComponent( ac, 1, -3, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, 0, -1, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, 1, -1, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, 1, 1, 0 );
			ac = new AddonComponent( 2805 );
			AddComponent( ac, 0, 3, 0 );
			ac = new AddonComponent( 2805 );
			AddComponent( ac, 1, 3, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, 0, -2, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 2797 );
			AddComponent( ac, 0, 2, 0 );
			ac = new AddonComponent( 2796 );
			AddComponent( ac, 1, -2, 0 );
			ac = new AddonComponent( 2796 );
			AddComponent( ac, 1, 0, 0 );
			ac = new AddonComponent( 2796 );
			AddComponent( ac, 1, 2, 0 );

		}

		public largefloralrugsouthAddon( Serial serial ) : base( serial )
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

	public class largefloralrugsouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new largefloralrugsouthAddon();
			}
		}

		[Constructable]
		public largefloralrugsouthAddonDeed()
		{
			Name = "Large Floral Rug South";
		}

		public largefloralrugsouthAddonDeed( Serial serial ) : base( serial )
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