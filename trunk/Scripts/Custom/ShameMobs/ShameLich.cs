using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a liche's corpse" )]
	public class ShameLich : BaseCreature
	{
		[Constructable]
		public ShameLich() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a lich";
			Body = 24;
			BaseSoundID = 0x3E9;

			SetStr( 171, 200 );
			SetDex( 126, 145 );
			SetInt( 276, 305 );

			SetHits( 103, 120 );

			SetDamage( 24, 26 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 55, 65 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 70.1, 80.0 );
			SetSkill( SkillName.Meditation, 85.1, 95.0 );
			SetSkill( SkillName.MagicResist, 80.1, 100.0 );
			SetSkill( SkillName.Tactics, 70.1, 90.0 );

			Fame = 8000;
			Karma = -8000;

			VirtualArmor = 50;

			switch ( Utility.Random( 20 ) )
			{
				case  0: PackItem( new ClumsyWand() ); break;
				case  1: PackItem( new FeebleWand() ); break;
				case  2: PackItem( new FireballWand() ); break;
				case  3: PackItem( new GreaterHealWand() ); break;
				case  4: PackItem( new HarmWand() ); break;
				case  5: PackItem( new HealWand() ); break;
				case  6: PackItem( new LightningWand() ); break;
				case  7: PackItem( new MagicArrowWand() ); break;
				case  8: PackItem( new ManaDrainWand() ); break;
				case  9: PackItem( new WeaknessWand() ); break;
			}

			if ( 0.02 > Utility.RandomDouble() )
				PackItem( new MediumStretchedHideEastDeed() );
			else if ( 0.02 > Utility.RandomDouble() )
				PackItem( new MediumStretchedHideSouthDeed() );
			else if ( 0.02 > Utility.RandomDouble() )
				PackItem( new BrownBearRugEastDeed() );
			else if ( 0.02 > Utility.RandomDouble() )
				PackItem( new BrownBearRugSouthDeed() );
			else if ( 0.01 > Utility.RandomDouble() )
				PackItem( new PolarBearRugEastDeed() );
			else if ( 0.01 > Utility.RandomDouble() )
				PackItem( new PolarBearRugSouthDeed() );
			
			//PackItem( new GnarledStaff() );
			PackNecroReg( 15, 25 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Average );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 3; } }

		public ShameLich( Serial serial ) : base( serial )
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