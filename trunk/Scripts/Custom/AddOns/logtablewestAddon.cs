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
	public class logtablewestAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new logtablewestAddonDeed();
			}
		}

		[ Constructable ]
		public logtablewestAddon()
		{
			AddComponent( new AddonComponent( 4574 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 4573 ), -1, 0, 0 );
			AddComponent( new AddonComponent( 4572 ), 1, 0, 0 );
			AddonComponent ac = null;

		}

		public logtablewestAddon( Serial serial ) : base( serial )
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

	public class logtablewestAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new logtablewestAddon();
			}
		}

		[Constructable]
		public logtablewestAddonDeed()
		{
			Name = "log table west";
		}

		public logtablewestAddonDeed( Serial serial ) : base( serial )
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