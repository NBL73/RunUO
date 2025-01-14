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

	
	public class NobleTobaccoSapling : WeedSeedZiolaUprawne
    {
        public override Type PlantType => typeof(NobleTobaccoPlant);

        [Constructable]
		public NobleTobaccoSapling( int amount ) : base( amount, 0x0CB0) 
		{
			Hue = 2126;
			Name = "Szczepka tytoniu szlachetnego";
			Stackable = true;
		}

		[Constructable]
		public NobleTobaccoSapling() : this( 1 )
		{
		}

		public NobleTobaccoSapling( Serial serial ) : base( serial )
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
	
	public class NobleTobaccoPlant : WeedPlantZiolaUprawne
    {
        public override Type SeedType => typeof(NobleTobaccoSapling);
        public override Type CropType => typeof(NobleTobaccoCrop);

		[Constructable] 
		public NobleTobaccoPlant() : base(0x0C97)
		{ 
			Hue = 2126;
			Name = "Tyton szlachetny";
			Stackable = true;
		}

		public NobleTobaccoPlant( Serial serial ) : base( serial ) 
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
	
	public class NobleTobaccoCrop : WeedCropZiolaUprawne
    {
        public override Type ReagentType => typeof(NobleTobacco);
		
		[Constructable]
		public NobleTobaccoCrop( int amount ) : base( amount, 0x0C93)
		{
			Hue = 2126;
			Name = "Swieze liscie tytoniu szlachetnego";
			Stackable = true;
		}

		[Constructable]
		public NobleTobaccoCrop() : this( 1 )
		{
		}

		public NobleTobaccoCrop( Serial serial ) : base( serial )
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