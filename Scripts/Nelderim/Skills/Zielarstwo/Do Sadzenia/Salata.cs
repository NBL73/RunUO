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
	public class SzczepkaSalata : SeedWarzywo
    {
        public override Type PlantType => typeof(KrzakSalata);

        [Constructable]
		public SzczepkaSalata( int amount ) : base( amount, 0xF27) 
		{
			Hue = 0x5E2;
			Name = "Nasiona salaty";
			Stackable = true;
		}

		[Constructable]
		public SzczepkaSalata() : this( 1 )
		{
		}

		public SzczepkaSalata( Serial serial ) : base( serial )
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
	
	public class KrzakSalata : PlantWarzywo
    {
        public override Type SeedType => typeof(SzczepkaSalata);
        public override Type CropType => typeof(Lettuce);

        [Constructable] 
		public KrzakSalata() : base(Utility.RandomList(0xC70, 0x0C71))
		{
            // seedling -
            //plant.PickGraphic = (0xC61); 'turnip', wiekszy niz salata
            //plant.FullGraphic = (0xC70); + 0x0C71
            Hue = 0;
			Name = "salata";
			Stackable = true;
        }

		public KrzakSalata( Serial serial ) : base( serial ) 
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