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
	public class brickfireplacesouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new brickfireplacesouthAddonDeed();
			}
		}

		[ Constructable ]
		public brickfireplacesouthAddon()
		{
			AddComponent( new AddonComponent( 2373 ), 1, 0, 0 );
			AddComponent( new AddonComponent( 2379 ), 0, 0, 0 );
			AddonComponent ac = null;

		}

		public brickfireplacesouthAddon( Serial serial ) : base( serial )
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

	public class brickfireplacesouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new brickfireplacesouthAddon();
			}
		}

		[Constructable]
		public brickfireplacesouthAddonDeed()
		{
			Name = "brick fireplace south";
		}

		public brickfireplacesouthAddonDeed( Serial serial ) : base( serial )
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