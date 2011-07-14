using System;
using Server;
using System.Collections;
using Server.Targeting;
using Server.Regions;
using Server.Spells;

namespace Server.Items
{
	public class InvisibilityRing : GoldRing
	{
		public virtual TimeSpan GetUseDelay{ get{ return TimeSpan.FromSeconds( 8.0 ); } }
		int m_Charges = 0;
		[Constructable]
		public InvisibilityRing( int Charge )
		{	
			m_Charges = Charge;
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		private static void ConsumeCharge( object parent, InvisibilityRing item )
		{
			item.Charges--;
			if ( item.Charges == 0 && parent is Mobile )
				((Mobile)parent).SendLocalizedMessage( 1019073 ); // This item is out of charges.
			item.InvalidateProperties();
		}

		public virtual void ApplyDelayTo( Mobile from )
		{
			from.BeginAction( typeof( InvisibilityRing ) );
			Timer.DelayCall( GetUseDelay, new TimerStateCallback( ReleaseInvisLock_Callback ), from );
		}

		public virtual void ReleaseInvisLock_Callback( object state )
		{
			((Mobile)state).EndAction( typeof( InvisibilityRing ) );
		}


		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.CanBeginAction( typeof( InvisibilityRing ) ) )
				return;
			if ( from.Hidden )
				return;
			if ( !Multis.DesignContext.Check( from ) )
				return;
			if ( !IsChildOf( from.Backpack ) && this != from.FindItemOnLayer( Layer.Ring ) )
			{
				from.SendMessage( "That must be either worn or in your pack to use it." );
				return;
			}
			if ( Charges == 0 )
			{
				from.SendLocalizedMessage( 1019073 ); // This item is out of charges.
				return;
			}
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( from.X, from.Y, from.Z + 16 ), from.Map, EffectItem.DefaultDuration ), 0x376A, 10, 15, 5045 );
				from.PlaySound( 0x3C4 );

				from.Hidden = true;
				from.Warmode = true;
				from.Warmode = false;
				ConsumeCharge( from, this );

				RemoveTimer( from );
				ApplyDelayTo( from );

				TimeSpan duration = TimeSpan.FromSeconds( 10 );

				Timer t = new InternalTimer( from, duration );

				m_Table[from] = t;

				t.Start();
		}

		private static Hashtable m_Table = new Hashtable();

		public static bool HasTimer( Mobile m )
		{
			return m_Table[m] != null;
		}

		public static void RemoveTimer( Mobile from )
		{
			Timer t = (Timer)m_Table[from];

			if ( t != null )
			{
				t.Stop();
				m_Table.Remove( from );
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer( Mobile from, TimeSpan duration ) : base( duration )
			{
				Priority = TimerPriority.OneSecond;
				m_Mobile = from;
			}

			protected override void OnTick()
			{
				m_Mobile.RevealingAction();
				RemoveTimer( m_Mobile );
			}
		}

		public InvisibilityRing( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1017347, m_Charges.ToString() ); // TeleportCharges ~1_val~
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
			writer.Write( (int) m_Charges );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Hue == 0x4F4 )
				Hue = 0x48D;
			m_Charges = (int)reader.ReadInt();
		}
	}
}