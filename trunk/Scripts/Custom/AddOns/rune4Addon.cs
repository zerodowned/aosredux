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
	public class rune4Addon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new rune4AddonDeed();
			}
		}

		[ Constructable ]
		public rune4Addon()
		{
			AddComponent( new AddonComponent( 3684 ), 0, 0, 0 );
			AddonComponent ac = null;

		}

		public rune4Addon( Serial serial ) : base( serial )
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

	public class rune4AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new rune4Addon();
			}
		}

		[Constructable]
		public rune4AddonDeed()
		{
			Name = "rune 4";
		}

		public rune4AddonDeed( Serial serial ) : base( serial )
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