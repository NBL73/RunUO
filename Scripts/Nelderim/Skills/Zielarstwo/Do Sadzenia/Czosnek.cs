using System;
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

	
	public class SzczepkaCzosnek : WeedSeedZiolaUprawne
    {
        public override Type PlantType => typeof(KrzakCzosnek);

		[Constructable]
		public SzczepkaCzosnek( int amount ) : base( amount, 0x18E3 ) 
		{
			Hue = 178;
			Name = "Szczepka czosnku";
			Stackable = true;
		}

		[Constructable]
		public SzczepkaCzosnek() : this( 1 )
		{
		}

		public SzczepkaCzosnek( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
	
	public class KrzakCzosnek : WeedPlantZiolaUprawne
    {
        public override Type SeedType => typeof(SzczepkaCzosnek);
        public override Type CropType => typeof(PlonCzosnek);

		[Constructable] 
		public KrzakCzosnek() : base( 0x18E2 )
		{ 
			Hue = 0;
			Name = "Lodyga czosnku";
			Stackable = true;			
		}

		public KrzakCzosnek( Serial serial ) : base( serial ) 
		{ 
			//m_plantedTime = DateTime.Now;	// ???
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
	
	public class PlonCzosnek : WeedCropZiolaUprawne
    {
        public override Type ReagentType => typeof(Garlic);
		
		[Constructable]
		public PlonCzosnek( int amount ) : base( amount, 0x18E4 )
		{
			Hue = 0;
			Name = "Glowka czosnku";
		}

		[Constructable]
		public PlonCzosnek() : this( 1 )
		{
		}

		public PlonCzosnek( Serial serial ) : base( serial )
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