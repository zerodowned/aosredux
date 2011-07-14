using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bone demon corpse" )]
	public class ShameBoneDemon : BaseCreature
	{
		[Constructable]
		public ShameBoneDemon() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bone demon";
			Body = 308;
			BaseSoundID = 0x48D;

			SetStr( 750 );
			SetDex( 120, 145 );
			SetInt( 120, 200 );

			SetHits( 3000 );

			SetDamage( 29, 32 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 55 );
			SetResistance( ResistanceType.Fire, 45 );
			SetResistance( ResistanceType.Cold, 60 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.EvalInt, 77.6, 87.5 );
			SetSkill( SkillName.Magery, 77.6, 87.5 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 50.1, 75.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 38;
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
		 if ( 1 > Utility.Random( 500 ) )
				c.DropItem( new FurnitureDyeTub() );
			else if ( 1 > Utility.Random( 500 ) )	
				c.DropItem( new LeatherDyeTub() );
			else if ( 1 > Utility.Random( 500 ) )	
				c.DropItem( new RewardBlackDyeTub() );
			else if ( 1 > Utility.Random( 500 ) )	
				c.DropItem( new RunebookDyeTub() );

		//base.OnDeath( c );
		 if ( 1 > Utility.Random( 100 ) )
				c.DropItem( new RewardRobe() );
			else if ( 1 > Utility.Random( 150 ) )	
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

		public ShameBoneDemon( Serial serial ) : base( serial )
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