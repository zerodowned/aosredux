using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using Server.Engines.PartySystem;

namespace Server.Items
{
	[FlipableAttribute( 0xE41, 0xE40 )]
	public class RewardChest : LockableContainer
	{
		private static Type[] m_MinorArtifacts = new Type[]
		{
			typeof( CandelabraOfSouls ), typeof( GoldBricks ), typeof( PhillipsWoodenSteed ),
			typeof( ArcticDeathDealer ), typeof( BlazeOfDeath ), typeof( BurglarsBandana ),
			typeof( CaptainQuacklebushsCutlass ), typeof( CavortingClub ), typeof( DreadPirateHat ),
			typeof( EnchantedTitanLegBone ), typeof( GwennosHarp ), typeof( IolosLute ),
			typeof( LunaLance ), typeof( NightsKiss ), typeof( NoxRangersHeavyCrossbow ),
			typeof( PolarBearMask ), typeof( VioletCourage ), typeof( HeartOfTheLion ),
			typeof( ColdBlood ), typeof( AlchemistsBauble ), typeof( SamuraiHelm )
		};
		private static Type[] m_Artifacts = new Type[]
		{
			typeof( Aegis ), typeof( ArcaneShield ), typeof( BraceletOfHealth ),
			typeof( ShadowDancerLeggings ), typeof( OrnamentOfTheMagician ), typeof( HatOfTheMagi ),
			typeof( StaffOfTheMagi ), typeof( TheTaskmaster ), typeof( SerpentsFang ),
			typeof( HelmOfInsight ), typeof( ArmorOfFortune ), typeof( LeggingsOfBane ),
			typeof( DivineCountenance ), typeof( SpiritOfTheTotem ), typeof( GauntletsOfNobility ),
			typeof( JackalsCollar ), typeof( RingOfTheElements ), typeof( RingOfTheVile ),
			typeof( VoiceOfTheFallenKing ), typeof( TunicOfFire ), typeof( MidnightBracers ),
			typeof( OrnateCrownOfTheHarrower ), typeof( HolyKnightsBreastplate ), typeof( TheBeserkersMaul ),
			typeof( TheDryadBow ), typeof( TheDragonSlayer ), typeof( LegacyOfTheDreadLord ),
			typeof( Frostbringer ), typeof( BreathOfTheDead ), typeof( BoneCrusher ), 
			typeof( BladeOfInsanity ), typeof( AxeOfTheHeavens ), typeof( HuntersHeaddress )
		};

		[Constructable]
		public RewardChest( int points ) : base( 0x9AA )
		{
		if ( points <= 10 && points >= 0 )
		{
			Name = "a reward chest";
			Hue = Utility.RandomList( 1426, 1626, 1175, 1366 );
		}
		else if ( points <= 20 && points >= 10 )
		{
			Name = "a sturdy reward chest";
			Hue = Utility.RandomList( 1155, 1626, 237, 512 );
		}
		else if ( points <= 30 && points >= 20 )
		{
			Name = "a heavy reward chest";
			Hue = Utility.RandomList( 222, 429, 1626, 1366 );
		}
		else if ( points <= 40 && points >= 30 )
		{
			Name = "a quality reward chest";
			Hue = Utility.RandomList( 49, 39, 29, 259 );
		}
		else if ( points <= 50 && points >= 40 )
		{
			Name = "an exceptional reward chest";
			Hue = Utility.RandomList( 49, 891, 229, 499 );
		}
		else if ( points <= 60 && points >= 50 )
		{
			Name = "an impressive reward chest";
			Hue = Utility.RandomList( 1151, 1501, 1160, 1163 );
		}
		else if ( points <= 70 && points >= 60 )
		{
			Name = "an extravagant reward chest";
			Hue = Utility.RandomList( 1173, 1157, 1160, 1163 );
		}
		else if ( points <= 80 && points >= 70 )
		{
			Name = "a glorious reward chest";
			Hue = Utility.RandomList( 1157, 1173, 1160, 1163 );
		}
		else if ( points >= 80 )
		{
			Name = "a legendary reward chest";
			Hue = Utility.RandomList( 1157, 1158, 1168, 1175);
		}
			Weight = 20.0;
			Fill( points );
		}

		public override int DefaultGumpID{ get{ return 0x43; } }
		public override int DefaultDropSound{ get{ return 0x42; } }

		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 18, 105, 144, 73 ); }
		}

		private void Fill( int points )
		{
		int level = 0;
		if ( points <=11 && points >=0 )
			level = 1;
		else if ( points <= 22 && points >= 11 )
			level = 2;
		else if ( points <= 34 && points >= 22 )
			level = 3;
		else if ( points <= 46 && points >= 34 )
			level = 4;
		else if ( points <= 58 && points >= 46 )
			level = 5;
		else if ( points <= 70 && points >= 58 )
			level = 6;
		else if ( points <= 85 && points >= 70 )
			level = 7;
		else if ( points <= 99 && points >= 85 )
			level = 8;
		else if ( points >= 100 )
			level = 9;

		switch ( level )
		{
			case 1:
				DropItem( new Gold( 200 ) );
				DropItem( new HairRestylingDeed() );
				if ( 0.1 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (4) + 2) );
				break;
			case 2:
				DropItem( new Gold( 400 ) );
				DropItem( new HairRestylingDeed() );
				DropItem( new TreasureMap (3, Map.Felucca) );
				if ( 0.2 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (4) + 2) );
				break;
			case 3:
				DropItem( new Gold( 800 ) );
				DropItem( new TreasureMap (4, Map.Felucca) );
				DropItem( new ClothingBlessDeed() );
				if ( 0.2 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (6) + 2) );
				break;
			case 4:
				DropItem( new Gold( 1000 ) );
				DropItem( new TreasureMap (5, Map.Felucca) );
				DropItem( new SpecialBeardDye() );
				if ( 0.2 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (6) + 2) );
				else if ( 0.1 > Utility.RandomDouble() )
					DropItem( new InvisibilityRing( Utility.Random (6) +2) );
				break;
			case 5:
				DropItem( new Gold( 1250 ) );
				DropItem( new SpecialHairDye() );
				DropItem( new TreasureMap (5, Map.Felucca) );
				if ( 0.3 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (6) + 2) );
				else if ( 0.2 > Utility.RandomDouble() )
					DropItem( new InvisibilityRing( Utility.Random (6) +2) );
				break;
			case 6:
				DropItem( new Gold( 1500) );
				DropItem( new RunicSewingKit( CraftResource.HornedLeather, 15 ) );
				DropItem( new RunicHammer( CraftResource.Agapite, 15 ) );
				if ( 0.4 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (6) + 2) );
				else if ( 0.3 > Utility.RandomDouble() )
					DropItem( new InvisibilityRing( Utility.Random (6) +2) );
				break;
			case 7:
				DropItem( new Gold( 2000 ) );
				DropItem( new RunicSewingKit( CraftResource.HornedLeather, 15 ) );
				DropItem( new RunicHammer( CraftResource.Agapite, 15 ) );
				if (0.3 > Utility.RandomDouble() )
					DropItem( (Item)Activator.CreateInstance( m_MinorArtifacts[Utility.Random(m_MinorArtifacts.Length)] ) );
				if ( 0.4 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (8) + 2) );
				else if ( 0.3 > Utility.RandomDouble() )
					DropItem( new InvisibilityRing( Utility.Random (8) +2) );
				break;
			case 8:
				DropItem( new Gold( 2500 ) );
				if ( 0.5 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (8) + 2) );
				else if ( 0.5 > Utility.RandomDouble() )
					DropItem( new InvisibilityRing( Utility.Random (8) +2) );

				if ( 0.5 > Utility.RandomDouble() )
					DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 10 ) );
				else
					DropItem( new RunicHammer( CraftResource.Valorite, 10 ) );

				DropItem( (Item)Activator.CreateInstance( m_MinorArtifacts[Utility.Random(m_MinorArtifacts.Length)] ) );
				break;
			case 9:
				if ( 0.8 > Utility.RandomDouble() )
					DropItem( new TeleportRing( Utility.Random (8) + 2) );
				else if ( 0.8 > Utility.RandomDouble() )
					DropItem( new InvisibilityRing( Utility.Random (8) +2) );
				if (0.3 > Utility.RandomDouble() )
					DropItem( (Item)Activator.CreateInstance( m_Artifacts[Utility.Random(m_Artifacts.Length)] ) );
				else
				{
					DropItem( (Item)Activator.CreateInstance( m_MinorArtifacts[Utility.Random(m_MinorArtifacts.Length)] ) );
					DropItem( new RunicSewingKit( CraftResource.BarbedLeather, 10) );
					DropItem( new RunicHammer( CraftResource.Valorite, 10 ) );
				}
				DropItem( new Gold( 3000 ) );
				break;
		}
			
			// FILL WITH GOODIES
		}

		public RewardChest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}