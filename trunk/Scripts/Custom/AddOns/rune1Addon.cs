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
	public class rune1Addon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new rune1AddonDeed();
			}
		}

		[ Constructable ]
		public rune1Addon()
		{
			AddComponent( new AddonComponent( 3690 ), 0, 0, 0 );
			AddonComponent ac = null;

		}

		public rune1Addon( Serial serial ) : base( serial )
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

	public class rune1AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new rune1Addon();
			}
		}

		[Constructable]
		public rune1AddonDeed()
		{
			Name = "rune 1";
		}

		public rune1AddonDeed( Serial serial ) : base( serial )
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