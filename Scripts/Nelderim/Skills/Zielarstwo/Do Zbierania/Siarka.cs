﻿using System;
using Server.Network;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Targets;
using Server.Items;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items.Crops
{
	public class ZrodloSiarka : WeedPlantZbieractwo
    {
        public override Type CropType => typeof(SurowiecSiarka);

		[Constructable] 
		public ZrodloSiarka() : base( 0x19B7 )
		{ 
			Hue = 0x31;
			Name = "Bryla pirytu";
			Stackable = true;
		}

		public ZrodloSiarka( Serial serial ) : base( serial ) 
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
	
	public class SurowiecSiarka : WeedCropZbieractwo
    {
        public override Type ReagentType => typeof(SulfurousAsh);
		
		[Constructable]
		public SurowiecSiarka( int amount ) : base( amount, 0x2244 )
		{
			Hue = 0x31;
			Name = "Odlamek pirytu";
			Stackable = true;
		}

		[Constructable]
		public SurowiecSiarka() : this( 1 )
		{
		}

		public SurowiecSiarka( Serial serial ) : base( serial )
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