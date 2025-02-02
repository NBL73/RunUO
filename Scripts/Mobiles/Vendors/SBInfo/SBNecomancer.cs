using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class SBNecromancer : SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBNecromancer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{
                
                //Add( new GenericBuyInfo( typeof( Spellbook ), 18, 50, 0xEFA, 0 ) );
				if ( Core.AOS )
				Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 50, 0x2253, 0 ) );

				Add( new GenericBuyInfo( typeof( Scalpel ), 50, 50, 4327, 0 ) );
				
				/*Add( new GenericBuyInfo( typeof( ScribesPen ), 10, 50, 0xFBF, 0 ) );

				Add( new GenericBuyInfo( typeof( BlankScroll ), 5, 50, 0x0E34, 0 ) );

				Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, 50, 0x1718, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( RecallRune ), 2000, 10 , 0x1F14, 0 ) );*/

				
				/*Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, 50, 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( AgilityPotion ), 15, 50, 0xF08, 0 ) );
				Add( new GenericBuyInfo( typeof( NightSightPotion ), 15, 50, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, 50, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 15, 50, 0xF09, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 15, 50, 0xF0A, 0 ) );
 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 15, 50, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 21, 50, 0xF0D, 0 ) );*/
				

				// szczepki 
				//Add( new GenericBuyInfo( typeof( SzczepkaCzosnek ), 70, 5, 0x18E3, 178 ) );
				//Add( new GenericBuyInfo( typeof( SzczepkaZenszen ), 70, 5, 0x18EB, 0 ) );
				//Add( new GenericBuyInfo( typeof( SzczepkaMandragora ), 70, 5, 0x18DD, 0 ) );
				//Add( new GenericBuyInfo( typeof( SzczepkaKrwawyMech ), 70, 5, 0x0DCD, 438 ) );
				//Add( new GenericBuyInfo( typeof( SzczepkaWilczaJagoda ), 70, 5, 0x18E7, 0 ) );
				// szczepki 

				Add( new GenericBuyInfo( typeof( BlackPearl ), 7, 50, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 7, 50, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 5, 50, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 5, 50, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 5, 50, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 5, 50, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 5, 50, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 5, 50, 0xF8C, 0 ) );
				Add( new GenericBuyInfo( typeof( DestroyingAngel ), 8, 50, 0xE1F, 0 ) );
				Add( new GenericBuyInfo( typeof( PetrafiedWood ), 8, 50, 0x97A, 0 ) );
				Add( new GenericBuyInfo( typeof( SpringWater ), 8, 50, 0xE24, 0 ) );
				
				Add( new GenericBuyInfo( typeof( MortarPestle ), 9, 50, 0xE9B, 0 ) );
				Add( new GenericBuyInfo( typeof( Bottle ), 5, 50, 0xF0E, 0 ) ); 

				if ( Core.AOS )
				{
					Add( new GenericBuyInfo( typeof( BatWing ), 6, 50, 0xF78, 0 ) );
					Add( new GenericBuyInfo( typeof( DaemonBlood ), 8, 50, 0xF7D, 0 ) );
					Add( new GenericBuyInfo( typeof( PigIron ), 7, 50, 0xF8A, 0 ) );
					Add( new GenericBuyInfo( typeof( NoxCrystal ), 8, 50, 0xF8E, 0 ) );
					Add( new GenericBuyInfo( typeof( GraveDust ), 6, 50, 0xF8F, 0 ) );
				}

				
				Type[] types = Loot.RegularScrollTypes;
				int circles = 5;
				for ( int i = 0; i < circles*8 && i < types.Length; ++i )
				{
					if (types[i] == typeof(RecallScroll)) continue; //We don't want recalls from NPCs
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					Add( new GenericBuyInfo( types[i], (((i / 8) + 1) * 500), 20, itemID, 0 ) );
				}
				
				
				Add( new GenericBuyInfo( typeof( BrownBook ), 40, 2, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( typeof( TanBook ), 40, 2, 0xFF0, 0 ) );
				Add( new GenericBuyInfo( typeof( BlueBook ), 40, 2, 0xFF2, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
                // 15.08.2012 :: zombie :: 15 -> 5
                Add( typeof( WizardsHat ), 5 );
				// zombie

				Add( typeof( BlackPearl ), 2 ); 
				Add( typeof( Bloodmoss ), 2 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( SpidersSilk ), 2 ); 
				Add( typeof( SulfurousAsh ), 2 ); 
				
				// szczepki 
				//Add( typeof( SzczepkaCzosnek ), 40 ); 
				//Add( typeof( SzczepkaZenszen ), 40 ); 
				//Add( typeof( SzczepkaMandragora ), 40 ); 
				//Add( typeof( SzczepkaKrwawyMech ), 40 ); 
				//Add( typeof( SzczepkaWilczaJagoda ), 40 ); 
				// szczepki 
				
				if ( Core.AOS )
				{
					Add( typeof( BatWing ), 2 );
					Add( typeof( DaemonBlood ), 2 );
					Add( typeof( PigIron ), 2 );
					Add( typeof( NoxCrystal ), 2 );
					Add( typeof( GraveDust ), 2 );
				}

				Add( typeof( RecallRune ), 50 );
				Add( typeof( Spellbook ), 25 );

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					Add( types[i], ((i / 8) + 2) * 2 );


				if ( Core.SE )
				{				
					Add( typeof( ExorcismScroll ), 35 );
					Add( typeof( AnimateDeadScroll ), 30 );
					Add( typeof( BloodOathScroll ), 18 );
					Add( typeof( CorpseSkinScroll ), 24 );
					Add( typeof( CurseWeaponScroll ), 20 );
					Add( typeof( EvilOmenScroll ), 20 );
					Add( typeof( PainSpikeScroll ), 16 );
					Add( typeof( SummonFamiliarScroll ), 26 );
					Add( typeof( HorrificBeastScroll ), 22 );
					Add( typeof( MindRotScroll ), 28 );
					Add( typeof( PoisonStrikeScroll ), 22 );
					Add( typeof( WraithFormScroll ), 25 );
					Add( typeof( LichFormScroll ), 38 );
					Add( typeof( StrangleScroll ), 33 );
					Add( typeof( WitherScroll ), 35 );
					Add( typeof( VampiricEmbraceScroll ), 45 );
					Add( typeof( VengefulSpiritScroll ), 48 );
					
				Add( typeof( ScribesPen ), 3 );
				Add( typeof( BrownBook ), 4 );
				Add( typeof( TanBook ), 4 );
				Add( typeof( BlueBook ), 4 );
				Add( typeof( BlankScroll ), 2 );
			}

		}
	}
	}
}