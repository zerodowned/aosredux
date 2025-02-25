using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ancient liche's corpse" )]
	public class AncientLich : BaseCreature
	{
		[Constructable]
		public AncientLich() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ancient lich" );
			Body = 78;
			BaseSoundID = 412;

			SetStr( 216, 305 );
			SetDex( 96, 115 );
			SetInt( 966, 1045 );

			SetHits( 560, 595 );

			SetDamage( 15, 27 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 25, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 25, 30 );

			SetSkill( SkillName.EvalInt, 120.1, 130.0 );
			SetSkill( SkillName.Magery, 120.1, 130.0 );
			SetSkill( SkillName.Meditation, 100.1, 101.0 );
			SetSkill( SkillName.Poisoning, 100.1, 101.0 );
			SetSkill( SkillName.MagicResist, 175.2, 200.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 75.1, 100.0 );

			Fame = 23000;
			Karma = -23000;

			VirtualArmor = 60;

			PackNecroReg( 150, 200 );
		}

		public override int GetIdleSound()
		{
			return 0x19D;
		}

		public override int GetAngerSound()
		{
			return 0x175;
		}

		public override int GetDeathSound()
		{
			return 0x108;
		}

		public override int GetAttackSound()
		{
			return 0xE2;
		}

		public override int GetHurtSound()
		{
			return 0x28B;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.UltraRich, 4 );
		}
		
		public override void OnDeath( Container c )
		{
		base.OnDeath ( c );
		 switch ( Utility.Random( 60 ) ) 
			{
				case 0:	c.DropItem( new RunicSewingKit( CraftResource.HornedLeather, 15 ) ); break;
				case 1:	c.DropItem( new RunicSewingKit( CraftResource.HornedLeather, 10 ) ); break;
				case 2:	c.DropItem( new RunicSewingKit( CraftResource.HornedLeather, 10 ) ); break;
				case 3:	c.DropItem( new RunicSewingKit( CraftResource.HornedLeather, 10 ) ); break;
				case 4:	c.DropItem( new RunicSewingKit( CraftResource.HornedLeather, 15 ) ); break;
				case 5:	c.DropItem( new RunicSewingKit( CraftResource.HornedLeather, 10 ) ); break;
				
			}
		}
		
			public override bool OnBeforeDeath()
        {
              switch (Utility.Random(75)) 
              {
                  case 0: PackItem(new TomeOfLostKnowledge());
                      break;
              }
              return base.OnBeforeDeath();
          
           }

		public override bool Unprovokable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public AncientLich( Serial serial ) : base( serial )
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