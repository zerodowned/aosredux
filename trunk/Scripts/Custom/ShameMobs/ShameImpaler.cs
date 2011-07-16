using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an impaler corpse" )]
	public class ShameImpaler : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.MortalStrike : WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ShameImpaler() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "impaler" );
			Body = 306;
			BaseSoundID = 0x2A7;

			SetStr( 160 );
			SetDex( 45 );
			SetInt( 190 );

			SetHits( 5000 );

			SetDamage( 28, 32 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 65 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 80 );

			SetSkill( SkillName.Meditation, 120.0 );
			SetSkill( SkillName.Poisoning, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 80.0 );

			Fame = 24000;
			Karma = -24000;

			VirtualArmor = 49;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 4 );
		}

		public override void OnDeath( Container c )
		{
		base.OnDeath ( c );
		 switch ( Utility.Random( 85 ) )
			{
				case 0:	c.DropItem( new PowerScroll( SkillName.Alchemy, 120) ); break;
				case 1:	c.DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 15 ) ); break;
				case 2:	c.DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 10 ) ); break;
				case 3:	c.DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 10 ) ); break;
				case 4:	c.DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 10 ) ); break;
				case 5:	c.DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 15 ) ); break;
				case 6:	c.DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 10 ) ); break;
				case 7:	c.DropItem( new PowerScroll( SkillName.Blacksmith, 120) ); break;
			}
		//base.OnDeath( c );
		 if ( 1 > Utility.Random( 1000 ) )
				c.DropItem( new FurnitureDyeTub() );
			else if ( 1 > Utility.Random( 1000 ) )	
				c.DropItem( new LeatherDyeTub() );
			else if ( 1 > Utility.Random( 1000 ) )	
				c.DropItem( new RewardBlackDyeTub() );
			else if ( 1 > Utility.Random( 1000 ) )	
				c.DropItem( new RunebookDyeTub() );

		//base.OnDeath( c );
		 if ( 1 > Utility.Random( 100 ) )
				c.DropItem( new RewardRobe() );
			else if ( 1 > Utility.Random( 200 ) )	
				c.DropItem( new RewardDress() );

		

		//base.OnDeath( c );
			if ( 1 > Utility.Random( 150 ) )
				c.DropItem( new SpecialHairDye() );
			else if ( 1 > Utility.Random( 150 ) )	
				c.DropItem( new SpecialBeardDye() );
			else if ( 1 > Utility.Random( 150 ) )	
				c.DropItem( new ClothingBlessDeed() );
		}


		//public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return (0.2 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }

		public override int TreasureMapLevel{ get{ return 5; } }

		public ShameImpaler( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 1200 )
				BaseSoundID = 0x2A7;
		}
	}
}