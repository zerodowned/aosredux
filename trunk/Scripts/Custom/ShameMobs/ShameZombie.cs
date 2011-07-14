using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a rotting corpse" )]
	public class ShameZombie : BaseCreature
	{
		[Constructable]
		public ShameZombie() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.25, 0.5 )
		{
			Name = "a zombie";
			Body = 3;
			BaseSoundID = 471;

			SetStr( 46, 70 );
			SetDex( 31, 50 );
			SetInt( 26, 40 );

			SetHits( 28, 42 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 40.0 );
			SetSkill( SkillName.Tactics, 35.1, 50.0 );
			SetSkill( SkillName.Wrestling, 35.1, 50.0 );

			Fame = 600;
			Karma = -600;

			VirtualArmor = 18;

			PackItem( new Bone() );
			if ( 0.01 > Utility.RandomDouble() )
				PackItem( new SmallStretchedHideEastDeed() );
			else if ( 0.01 > Utility.RandomDouble() )
				PackItem( new SmallStretchedHideSouthDeed() );
			// TODO: body parts
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public ShameZombie( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}