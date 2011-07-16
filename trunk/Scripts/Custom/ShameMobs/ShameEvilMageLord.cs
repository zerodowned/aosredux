using System; 
using Server;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an evil mage lord corpse" )] 
	public class ShameEvilMageLord : BaseCreature 
	{ 
		int amountofpowder = Utility.Random(10);
		[Constructable] 
		public ShameEvilMageLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = NameList.RandomName( "evil mage lord" );
			Body = Utility.RandomList( 125, 126 );
 
			PackItem( new WizardsHat( ) ); 

			SetStr( 81, 105 );
			SetDex( 191, 215 );
			SetInt( 196, 250 );

			SetHits( 149, 163 );

			SetDamage( 9, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 70 );
			SetResistance( ResistanceType.Fire, 40, 70 );
			SetResistance( ResistanceType.Cold, 40, 70 );
			SetResistance( ResistanceType.Poison, 40, 70 );
			SetResistance( ResistanceType.Energy, 40, 70 );

			SetSkill( SkillName.EvalInt, 90.2, 100.0 );
			SetSkill( SkillName.Magery, 98.1, 100.0 );
			SetSkill( SkillName.Meditation, 97.5, 100.0 );
			SetSkill( SkillName.MagicResist, 97.5, 120.0 );
			SetSkill( SkillName.Tactics, 95.0, 100.5 );
			SetSkill( SkillName.Wrestling, 80.3, 120.0 );

			Fame = 10500;
			Karma = -10500;

			VirtualArmor = 16;

			PackReg( 6 );

			if ( Utility.RandomBool() )
				PackItem( new Shoes() );
			else
				PackItem( new Sandals() );

			if ( 0.08 > Utility.RandomDouble() )
				PackItem( new PowderOfTranslocation( amountofpowder ) );

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

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			//AddLoot( LootPack.Average );
			//AddLoot( LootPack.MedScrolls, 2 );
		}

		public override void OnDeath( Container c )
		{
		base.OnDeath ( c );
		 switch ( Utility.Random( 500 ))  // 1% chance
			{
				case 0:	c.DropItem( new EtherealHorse() ); break;
				case 1:	c.DropItem( new EtherealLlama() ); break;
				case 2:	c.DropItem( new EtherealOstard() ); break;
				case 3:	c.DropItem( new EtherealHorse() ); break;
				case 4:	c.DropItem( new EtherealHorse() ); break;
				case 5:	c.DropItem( new EtherealOstard() ); break;
			}
		base.OnDeath ( c );
			if ( 0.01 > Utility.RandomDouble() )
				c.DropItem( new RewardRobe() );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int TreasureMapLevel{ get{ return Core.AOS ? 2 : 0; } }

		public ShameEvilMageLord( Serial serial ) : base( serial ) 
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