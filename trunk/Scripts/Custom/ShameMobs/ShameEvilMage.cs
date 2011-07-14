using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an evil mage corpse" )] 
	public class ShameEvilMage : BaseCreature 
	{
		int amountofpowder = Utility.Random(5);
		[Constructable] 
		public ShameEvilMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = NameList.RandomName( "evil mage" );
			Title = "the evil mage";
			Body = 124;

			SetStr( 81, 105 );
			SetDex( 91, 115 );
			SetInt( 156, 194 );

			SetHits( 128, 164 );

			SetDamage( 7, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 60 );
			SetResistance( ResistanceType.Fire, 55, 60 );
			SetResistance( ResistanceType.Poison, 55, 60 );
			SetResistance( ResistanceType.Energy, 55, 60 );

			SetSkill( SkillName.EvalInt, 85.1, 100.0 );
			SetSkill( SkillName.Magery, 85.1, 100.0 );
			SetSkill( SkillName.MagicResist, 85.0, 97.5 );
			SetSkill( SkillName.Tactics, 85.0, 87.5 );
			SetSkill( SkillName.Wrestling, 80.2, 90.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 16;

			PackReg( 6 );


	
			switch ( Utility.Random( 150 ) )
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

		public override void OnDeath( Container c )
		{
		base.OnDeath ( c );
		 switch ( Utility.Random( 550 ))  // 1% chance
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

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			//AddLoot( LootPack.MedScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int TreasureMapLevel{ get{ return Core.AOS ? 1 : 0; } }

		public ShameEvilMage( Serial serial ) : base( serial )
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