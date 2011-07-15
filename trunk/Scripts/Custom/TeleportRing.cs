using System;
using Server;
using Server.Targeting;
using Server.Regions;
using Server.Spells;

namespace Server.Items
{
	public class TeleportRing : GoldRing
	{
		public virtual TimeSpan GetUseDelay{ get{ return TimeSpan.FromSeconds( 4.0 ); } }
		int m_Charges = 0;
		[Constructable]
		public TeleportRing( int Charge )
		{	
			m_Charges = Charge;
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		private static void ConsumeCharge( object parent, TeleportRing item )
		{
			item.Charges--;
			if ( item.Charges == 0 && parent is Mobile )
				((Mobile)parent).SendLocalizedMessage( 1019073 ); // This item is out of charges.
			item.InvalidateProperties();
		}

		public virtual void ApplyDelayTo( Mobile from )
		{
			from.BeginAction( typeof( TeleportRing ) );
			Timer.DelayCall( GetUseDelay, new TimerStateCallback( ReleaseTeleportLock_Callback ), from );
		}

		public virtual void ReleaseTeleportLock_Callback( object state )
		{
			((Mobile)state).EndAction( typeof( TeleportRing ) );
		}


		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.CanBeginAction( typeof( TeleportRing ) ) )
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
			from.Target = new InternalTarget( this );
		}

		public class InternalTarget : Target
		{
			private TeleportRing m_Jewel;
			public InternalTarget( TeleportRing jewel ) : base( 12, true, TargetFlags.None )
			{
				m_Jewel = jewel;
			}
			protected override void OnTarget( Mobile from, object targeted )
			{
				IPoint3D p = targeted as IPoint3D;
				if ( p != null )
				{
					Map map = from.Map;
					SpellHelper.GetSurfaceTop( ref p );
					if ( !SpellHelper.CheckTravel( from, TravelCheckType.TeleportFrom ) )
					{
					}
					else if ( !SpellHelper.CheckTravel( from, map, new Point3D( p ), TravelCheckType.TeleportTo ) )
					{
					}
					else if ( map == null || !map.CanSpawnMobile( p.X, p.Y, p.Z ) )
						from.SendLocalizedMessage( 501942 ); // That location is blocked.
					else if ( SpellHelper.CheckMulti( new Point3D( p ), map ) )
						from.SendLocalizedMessage( 501942 ); // That location is blocked.
					else
					{
						Mobile m = from;
						ConsumeCharge( m, m_Jewel );
						Point3D fromloc = m.Location;
						Point3D toloc = new Point3D( p );
						m.Location = toloc;
						m.ProcessDelta();
						m_Jewel.ApplyDelayTo( from );
						if ( m.AccessLevel < AccessLevel.Counselor || !m.Hidden )
						{
							Effects.SendLocationParticles( EffectItem.Create( fromloc, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
							Effects.SendLocationParticles( EffectItem.Create(   toloc, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );
							m.PlaySound( 0x1FE );
						}
					}
				}
			}
		}

		public TeleportRing( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1017337, m_Charges.ToString() ); // TeleportCharges ~1_val~
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