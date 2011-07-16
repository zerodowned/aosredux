using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles		// Define what it actually is
{
	[CorpseName( "a human corpse" )]        // Corpse details
	public class BlacksmithLord : BaseCreature  // Use basic base creature stats for unset
	{
		[Constructable]			// Make it Spawnable in game
		public BlacksmithLord() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.2, 0.4 ) // Set AI
		{
			if ( Female = Utility.RandomBool() )   // Make it 50/50 male/female
			{
				Body = 0x191;					// Give it a female body
				Name = NameList.RandomName( "evil mage" );		// Choose a female name
			}
			else							// Or
			{
				Body = 0x190;					// Give it a male body
				Name = NameList.RandomName( "evil mage" );		// Choose a Male name
			}
			Hue = Utility.RandomSkinHue();

			SetStr( 450, 560 );
			SetDex( 90, 135 );       // Set Stats
			SetInt( 60, 65 );
			SetHits( 450, 550 );

			SetDamage( 28, 32 );	// Set Damage

			SetDamageType( ResistanceType.Physical, 100 ); 

			SetSkill( SkillName.MagicResist, 100.1, 120.0 );
			SetSkill( SkillName.Tactics, 95.1, 110.0 );
			SetSkill( SkillName.Wrestling, 95.1, 110.0 );
			SetSkill( SkillName.Fencing, 95.1, 110.0 );		// Set Skills
			SetSkill( SkillName.Macing, 95.1, 110.0 );
			SetSkill( SkillName.Swords, 95.1, 110.0 );

			SetResistance( ResistanceType.Physical, 55, 65 ); 	//Set Resistances
			SetResistance( ResistanceType.Fire, 55, 60 );
			SetResistance( ResistanceType.Cold, 55, 60 );
			SetResistance( ResistanceType.Poison, 55, 60 );
			SetResistance( ResistanceType.Energy, 55, 60 );


			Fame = 15000;						// Set Fame/Karma
			Karma = -15000;

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNondyedHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );

			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new RunicHammer( CraftResource.Gold, 10 ) );		// Roll for a Runic
			else if ( 0.03 > Utility.RandomDouble() )		// If it fails	
				PackItem( new AncientSmithyHammer( 30, 50 ) );			// Roll for a ancient
			if ( 0.03 > Utility.RandomDouble() )
				PackItem( new PowerScroll( SkillName.Tailoring, 110) );
			if ( 0.03 > Utility.RandomDouble() )
				PackItem( new PowerScroll( SkillName.Blacksmith, 110) );

			switch ( Utility.Random( 5 ))  		// Equip 1 of 5 weapons
			{ 
				case 0: Mace weapon = new Mace();
					weapon.Movable = false;
					weapon.Crafter = this;
					weapon.Quality = WeaponQuality.Exceptional;
					AddItem( weapon ); break;

				case 1: Maul weapona = new Maul();
					weapona.Movable = false;
					weapona.Crafter = this;
					weapona.Quality = WeaponQuality.Exceptional;
					AddItem( weapona ); break;

				case 2: WarHammer weaponb = new WarHammer();
					weaponb.Movable = false;
					weaponb.Crafter = this;
					weaponb.Quality = WeaponQuality.Exceptional;
					AddItem( weaponb ); break;

				case 3: HammerPick weaponc = new HammerPick();
					weaponc.Movable = false;
					weaponc.Crafter = this;
					weaponc.Quality = WeaponQuality.Exceptional;
					AddItem( weaponc ); break;

				case 4: WarMace weapond = new WarMace();
					weapond.Movable = false;
					weapond.Crafter = this;
					weapond.Quality = WeaponQuality.Exceptional;
					AddItem( weapond ); break;
			}

			PlateChest chest = new PlateChest();		// Create a plate Chest
			chest.Quality = ArmorQuality.Exceptional;
			chest.Crafter = this;				
			chest.Hue = 1146;
			chest.Movable = false;				// Make it dissapear on death
			AddItem( chest );				// Add it as equip
			
			PlateArms arms = new PlateArms();
			arms.Quality = ArmorQuality.Exceptional;
			arms.Crafter = this;				
			arms.Hue = 1146;
			arms.Movable = false;
			AddItem( arms );
			
			PlateGloves gloves = new PlateGloves();
			gloves.Quality = ArmorQuality.Exceptional;
			gloves.Crafter = this;				
			gloves.Hue = 1146;
			gloves.Movable = false;
			AddItem( gloves );
			
			PlateGorget gorget = new PlateGorget();
			gorget.Quality = ArmorQuality.Exceptional;
			gorget.Crafter = this;				
			gorget.Hue = 1146;
			gorget.Movable = false;
			AddItem( gorget );
			
			PlateLegs legs = new PlateLegs();
			legs.Quality = ArmorQuality.Exceptional;
			legs.Crafter = this;				
			legs.Hue = 1146;
			legs.Movable = false;
			AddItem( legs );

		}

		public override void GenerateLoot()			// Make it give some loot
		{
			AddLoot( LootPack.FilthyRich );			// Select the quality of loot Pack
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Rich );	
		}

		public override int Meat{ get{ return 1; } }		// Carving its corpse gives meat
		public override bool AlwaysMurderer{ get{ return true; } }	// It's always red
		public override bool ShowFameTitle{ get{ return true; } }	// Doesn't show title

		public override OppositionGroup OppositionGroup			// It is aggresive towards Orcs
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public BlacksmithLord( Serial serial ) : base( serial )    // Not a clue! Looks nice though!
		{
		}

		public override void Serialize( GenericWriter writer ) // See Above!
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )  // See above!
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}