using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles		// Define what it actually is
{
	[CorpseName( "a human corpse" )]        // Corpse details
	public class DerangedBlacksmith : BaseCreature  // Use basic base creature stats for unset
	{
		[Constructable]			// Make it Spawnable in game
		public DerangedBlacksmith() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.2, 0.4 ) // Set AI
		{
			if ( Female = Utility.RandomBool() )   // Make it 50/50 male/female
			{
				Body = 0x191;					// Give it a female body
				Name = NameList.RandomName( "female" );		// Choose a female name
			}
			else							// Or
			{
				Body = 0x190;					// Give it a male body
				Name = NameList.RandomName( "male" );		// Choose a Male name
			}
			Hue = Utility.RandomSkinHue();

			SetStr( 145, 165 );
			SetDex( 116, 125 );       // Set Stats
			SetInt( 60, 65 );

			SetDamage( 25, 32 );	// Set Damage

			SetDamageType( ResistanceType.Physical, 100 ); 

			SetSkill( SkillName.MagicResist, 85.1, 100.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 40.1, 60.0 );
			SetSkill( SkillName.Fencing, 80.1, 90.0 );		// Set Skills
			SetSkill( SkillName.Macing, 80.1, 90.0 );
			SetSkill( SkillName.Swords, 80.1, 90.0 );
			SetSkill( SkillName.Anatomy, 80.1, 90.0 );

			SetResistance( ResistanceType.Physical, 40, 45 ); 	//Set Resistances
			SetResistance( ResistanceType.Fire, 40, 45 );
			SetResistance( ResistanceType.Cold, 40, 45 );
			SetResistance( ResistanceType.Poison, 40, 45 );
			SetResistance( ResistanceType.Energy, 40, 45 );


			Fame = 2500;						// Set Fame/Karma
			Karma = -2500;

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNondyedHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );

			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new SturdyPickaxe() );		// Roll for a pickaxe
			else if ( 0.05 > Utility.RandomDouble() )		// If it fails	
				PackItem( new SturdyShovel() );			// Roll for a Shovel	

			if ( 0.02 > Utility.RandomDouble() )
				PackItem( new RunicHammer( CraftResource.Bronze, 10 ) );  // Roll for runic hammer
			//if ( 0.05 > Utility.RandomDouble() )
			//	PackItem( new PowderOfTemperament() );

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
			chest.Hue = 2406;
			chest.Movable = false;				// Make it dissapear on death
			AddItem( chest );				// Add it as equip
			
			PlateArms arms = new PlateArms();
			arms.Quality = ArmorQuality.Exceptional;
			arms.Crafter = this;				
			arms.Hue = 2406;
			arms.Movable = false;
			AddItem( arms );
			
			PlateGloves gloves = new PlateGloves();
			gloves.Quality = ArmorQuality.Exceptional;
			gloves.Crafter = this;				
			gloves.Hue = 2406;
			gloves.Movable = false;
			AddItem( gloves );
			
			PlateGorget gorget = new PlateGorget();
			gorget.Quality = ArmorQuality.Exceptional;
			gorget.Crafter = this;				
			gorget.Hue = 2406;
			gorget.Movable = false;
			AddItem( gorget );
			
			PlateLegs legs = new PlateLegs();
			legs.Quality = ArmorQuality.Exceptional;
			legs.Crafter = this;				
			legs.Hue = 2406;
			legs.Movable = false;
			AddItem( legs );

		}

		public override void GenerateLoot()			// Make it give some loot
		{
			AddLoot( LootPack.FilthyRich );			// Select the quality of loot Pack
			AddLoot( LootPack.Average );	
		}

		public override int Meat{ get{ return 1; } }		// Carving its corpse gives meat
		public override bool AlwaysMurderer{ get{ return true; } }	// It's always red
		public override bool ShowFameTitle{ get{ return false; } }	// Doesn't show title

		public override OppositionGroup OppositionGroup			// It is aggresive towards Orcs
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public DerangedBlacksmith( Serial serial ) : base( serial )    // Not a clue! Looks nice though!
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