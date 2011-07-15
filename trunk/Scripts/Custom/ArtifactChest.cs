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
	public class ArtifactChest : LockableContainer
	{
		public override int LabelNumber{ get{ return 3000541; } }

		private static int[] m_ItemIDs = new int[]
		{
			0x9AA
		};

		private string m_Name;

		[Constructable]
		public ArtifactChest( ) : base( Utility.RandomList( m_ItemIDs ) )
		{
			Name = "Ancient Chest";
			Movable = false;
			Hue = 1175;
			Fill();
		}

		public override int DefaultGumpID{ get{ return 0x42; } }
		public override int DefaultDropSound{ get{ return 0x42; } }

		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 18, 105, 144, 73 ); }
		}

		private void Fill()
		{
			Locked = true;
			LockLevel = 8;
			RequiredSkill = 97;

			switch ( Utility.Random(120) )
			{
				case 0: DropItem( new DivineCountenance() ); break;
				case 1: DropItem( new HatOfTheMagi() ); break;
				case 2: DropItem( new HuntersHeaddress() ); break;
				case 3: DropItem( new SpiritOfTheTotem() ); break;
				case 4: DropItem( new AxeOfTheHeavens() ); break;
				case 5: DropItem( new BladeOfInsanity() ); break;
				case 6: DropItem( new BoneCrusher() ); break;
				case 7: DropItem( new BreathOfTheDead() ); break;
				case 8: DropItem( new Frostbringer() ); break;
				case 9: DropItem( new LegacyOfTheDreadLord() ); break;
				case 10: DropItem( new SerpentsFang() ); break;
				case 11: DropItem( new StaffOfTheMagi() ); break;
				case 12: DropItem( new TheBeserkersMaul() ); break;
				case 13: DropItem( new TheDragonSlayer() ); break;
				case 14: DropItem( new TheDryadBow() ); break;
				case 15: DropItem( new TheTaskmaster() ); break;
				case 16: DropItem( new BraceletOfHealth() ); break;
				case 17: DropItem( new ArmorOfFortune() ); break;
				case 18: DropItem( new GauntletsOfNobility() ); break;
				case 19: DropItem( new HelmOfInsight() ); break;
				case 20: DropItem( new HolyKnightsBreastplate() ); break;
				case 21: DropItem( new JackalsCollar() ); break;
				case 22: DropItem( new LeggingsOfBane() ); break;
				case 23: DropItem( new MidnightBracers() ); break;
				case 24: DropItem( new OrnateCrownOfTheHarrower() ); break;
				case 25: DropItem( new ShadowDancerLeggings() ); break;
				case 26: DropItem( new TunicOfFire() ); break;
				case 27: DropItem( new VoiceOfTheFallenKing() ); break;
				case 28: DropItem( new OrnamentOfTheMagician() ); break;
				case 29: DropItem( new RingOfTheVile() ); break;
				case 30: DropItem( new RingOfTheElements() ); break;
				case 31: DropItem( new Aegis() ); break;
				case 32: DropItem( new ArcaneShield() ); break;
			}

		}

		public ArtifactChest( Serial serial ) : base( serial )
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