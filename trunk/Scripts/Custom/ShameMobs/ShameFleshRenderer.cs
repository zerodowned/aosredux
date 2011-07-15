using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fleshrenderer corpse" )]
	public class ShameFleshRenderer : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.Dismount : WeaponAbility.ParalyzingBlow;
		}

		[Constructable]
		public ShameFleshRenderer() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fleshrenderer";
			Body = 315;

			SetStr( 401, 460 );
			SetDex( 201, 210 );
			SetInt( 221, 260 );

			SetHits( 4500 );

			SetDamage( 16, 20 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 70, 60 );
			SetResistance( ResistanceType.Fire, 45, 55 );
			SetResistance( ResistanceType.Cold, 45, 55 );
			SetResistance( ResistanceType.Poison, 80 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.MagicResist, 155.1, 160.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 23000;
			Karma = -23000;

			VirtualArmor = 24;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich,4 );
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

		public override bool Unprovokable{ get{ return true; } }
		public override bool Uncalmable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int TreasureMapLevel{ get{ return 1; } }

		public override int GetAttackSound()
		{
			return 0x34C;
		}

		public override int GetHurtSound()
		{
			return 0x354;
		}

		public override int GetAngerSound()
		{
			return 0x34C;
		}

		public override int GetIdleSound()
		{
			return 0x34C;
		}

		public override int GetDeathSound()
		{
			return 0x354;
		}

		public ShameFleshRenderer( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 660 )
				BaseSoundID = -1;
		}
	}
}