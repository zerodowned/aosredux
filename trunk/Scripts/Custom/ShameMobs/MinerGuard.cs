using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles		// Define what it actually is
{
	[CorpseName( "a human corpse" )]        // Corpse details
	public class MinerGuard : BaseCreature  // Use basic base creature stats for unset
	{
		[Constructable]			// Make it Spawnable in game
		public MinerGuard() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.2, 0.4 ) // Set AI
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

			SetStr( 106, 125 );
			SetDex( 106, 115 );       // Set Stats
			SetInt( 51, 65 );
			Hue = Utility.RandomSkinHue();

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNondyedHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );

			SetDamage( 23, 27 );	// Set Damage

			SetDamageType( ResistanceType.Physical, 100 ); 

			SetSkill( SkillName.MagicResist, 85.1, 100.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 40.1, 60.0 );
			SetSkill( SkillName.Fencing, 80.1, 90.0 );		// Set Skills
			SetSkill( SkillName.Macing, 80.1, 90.0 );
			SetSkill( SkillName.Swords, 80.1, 90.0 );
			SetSkill( SkillName.Anatomy, 80.1, 90.0 );

			SetResistance( ResistanceType.Physical, 30, 35 ); 	//Set Resistances
			SetResistance( ResistanceType.Fire, 25, 30 );
			SetResistance( ResistanceType.Cold, 25, 30 );
			SetResistance( ResistanceType.Poison, 25, 30 );
			SetResistance( ResistanceType.Energy, 25, 30 );


			Fame = 1500;						// Set Fame/Karma
			Karma = -1500;

			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new SturdyPickaxe() );		// Roll for a pickaxe
			else if ( 0.05 > Utility.RandomDouble() )		// If it fails	
				PackItem( new SturdyShovel() );			// Roll for a Shovel	

			if ( 0.02 > Utility.RandomDouble() )
				PackItem( new RunicHammer( CraftResource.Copper, 10 ) );  // Roll for runic hammer

			switch ( Utility.Random( 5 ))  		// Equip 1 of 5 weapons
			{ 
				case 0: AddItem( new Spear() ); break;
				case 1: AddItem( new Halberd() ); break;
				case 2: AddItem( new WarHammer() ); break;
				case 3: AddItem( new Bardiche() ); break;
				case 4: AddItem( new DoubleAxe() ); break;
			}

			PlateChest chest = new PlateChest(); 		// Create a plate Chest
			chest.Movable = false;				// Make it dissapear on death
			AddItem( chest );				// Add it as equip
			
			PlateArms arms = new PlateArms();
			arms.Movable = false;
			AddItem( arms );
			
			PlateGloves gloves = new PlateGloves();
			gloves.Movable = false;
			AddItem( gloves );
			
			PlateGorget gorget = new PlateGorget();
			gorget.Movable = false;
			AddItem( gorget );
			
			PlateLegs legs = new PlateLegs();
			legs.Movable = false;
			AddItem( legs );

		}

		public override void GenerateLoot()			// Make it give some loot
		{
			AddLoot( LootPack.Average );			// Select the quality of loot Pack
		}

		public override int Meat{ get{ return 1; } }		// Carving its corpse gives meat
		public override bool AlwaysMurderer{ get{ return true; } }	// It's always red
		public override bool ShowFameTitle{ get{ return false; } }	// Doesn't show title

		public override OppositionGroup OppositionGroup			// It is aggresive towards Orcs
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public MinerGuard( Serial serial ) : base( serial )    // Not a clue! Looks nice though!
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