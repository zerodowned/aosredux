using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a human corpse" )]
	public class DerangedMiner : BaseCreature
	{
		[Constructable]
		public DerangedMiner() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.2, 0.4 )
		{
			if ( Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );
			}
			Hue = Utility.RandomSkinHue();

			SetStr( 96, 115 );
			SetDex( 86, 105 );
			SetInt( 51, 65 );

			SetDamage( 23, 27 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Fencing, 60.0, 82.5 );
			SetSkill( SkillName.Macing, 60.0, 82.5 );
			SetSkill( SkillName.Poisoning, 60.0, 82.5 );
			SetSkill( SkillName.MagicResist, 57.5, 80.0 );
			SetSkill( SkillName.Swords, 60.0, 82.5 );
			SetSkill( SkillName.Tactics, 60.0, 82.5 );

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNondyedHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );

			Fame = 1000;
			Karma = -1000;

			PackItem( new Bandage( Utility.RandomMinMax( 1, 15 ) ) );

			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new SturdyPickaxe() );
			else if ( 0.05 > Utility.RandomDouble() )
				PackItem( new SturdyShovel() );

			AddItem( new Pickaxe() );
			AddItem( new RingmailGloves() );
			AddItem( new ChainLegs() );
			AddItem( new IronOre(10) );

			if ( 0.2 > Utility.RandomDouble() )
				AddItem( new Bascinet() );
			else if ( 0.1 > Utility.RandomDouble() )
				AddItem( new CloseHelm() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int Meat{ get{ return 1; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		//public override bool IsEnemy( Mobile m )
		//{
		//	if ( m.BodyMod == 183 || m.BodyMod == 184 )
		//		return false;
		//
		//	return base.IsEnemy( m );
		//}

		//public override void AggressiveAction( Mobile aggressor, bool criminal )
		//{
		//	base.AggressiveAction( aggressor, criminal );

		//	if ( aggressor.BodyMod == 183 || aggressor.BodyMod == 184 )
		//	{
		//		AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
		//		aggressor.BodyMod = 0;
		//		aggressor.HueMod = -1;
		//		aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
		//		aggressor.PlaySound( 0x307 );
		//		aggressor.SendLocalizedMessage( 1040008 ); // Your skin is scorched as the tribal paint burns away!

		//		if ( aggressor is PlayerMobile )
		//			((PlayerMobile)aggressor).SavagePaintExpiration = TimeSpan.Zero;
		//	}
		//}

		//public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		//{
		//	if ( to is Dragon || to is WhiteWyrm || to is SwampDragon || to is Drake || to is Nightmare || to is Daemon )
		//		damage *= 5;
		//}

		public DerangedMiner( Serial serial ) : base( serial )
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