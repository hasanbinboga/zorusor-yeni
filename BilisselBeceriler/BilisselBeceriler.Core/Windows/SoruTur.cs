/*

insert license info here

*/

using System;
using System.Collections;
using System.Collections.Generic;


namespace BilisselBeceriler.Entities.Windows
{
	/// <summary>
	/// Generated by MyGeneration using the NHibernate Object Mapping 1.3.1 by Grimaldi Giuseppe (giuseppe.grimaldi@infracom.it)
	/// </summary>
	[Serializable]
	public class SoruTur 
	{
		#region Private Members
		
		// Variabili di stato
		private bool _isChanged;
		private bool _isDeleted;

		// Primary Key(s) 
		private long _id; 
		
		// Properties 
		private string _ad; 
		private string _aciklama; 
		
		// One-to-many relations 
		private IList<PlanSoruTur> _listPlanSoruTur;
		private IList<Soru> _listSoru;
		private IList<SoruTurHavuz> _listSoruTurHavuz;
		private IList<SoruTurSoruSablon> _listSoruTurSoruSablon;
		private IList<SoruTurZorlukAyar> _listSoruTurZorlukAyar;		

		#endregion
		
		#region Default ( Empty ) Class Constructor
		
		/// <summary>
		/// default constructor
		/// </summary>
		public SoruTur()
		{
			_id = 0; 
			_ad = null; 
			_aciklama = null; 
			_listPlanSoruTur = null; 
			_listSoru = null; 
			_listSoruTurHavuz = null; 
			_listSoruTurSoruSablon = null; 
			_listSoruTurZorlukAyar = null; 
		}
		
		#endregion // End of Default ( Empty ) Class Constructor
		
		#region Full Constructor
		
		/// <summary>
		/// full constructor
		/// </summary>
		public SoruTur(long id, string ad, string aciklama)
		{
			_id = id; 
			_ad = ad; 
			_aciklama = aciklama; 
			_listPlanSoruTur = null; 
			_listSoru = null; 
			_listSoruTurHavuz = null; 
			_listSoruTurSoruSablon = null; 
			_listSoruTurZorlukAyar = null; 
		}
		
		#endregion // End Full Constructor
		
		#region Required Fields Only Constructor
		
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public SoruTur(long id, string ad)
		{
			_id = id; 
			_ad = ad; 
			_aciklama = null; 
			_listPlanSoruTur = null; 
			_listSoru = null; 
			_listSoruTurHavuz = null; 
			_listSoruTurSoruSablon = null; 
			_listSoruTurZorlukAyar = null; 
		}
		
		#endregion // End Required Fields Only Constructor

		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>		
		public virtual long Id
		{
			get { return _id; }
			set { _isChanged |= (_id != value); _id = value; }
		} 
	  
		/// <summary>
		/// Soru Türünün Adı
		/// </summary>		
		public virtual string Ad
		{
			get { return _ad; }
			set	
			{
				if ( value != null )
					if( value.Length > 80)
						throw new ArgumentOutOfRangeException("Invalid value for Ad", value, value.ToString());
				
				_isChanged |= (_ad != value); _ad = value;
			}
		} 
	  
		/// <summary>
		/// ilgili Soru Türünün nasıl uygulanacağına ve neler kazandırdığına ilişkin genel açıklamalar.
		/// </summary>		
		public virtual string Aciklama
		{
			get { return _aciklama; }
			set	
			{
				if ( value != null )
					if( value.Length > 2147483647)
						throw new ArgumentOutOfRangeException("Invalid value for Aciklama", value, value.ToString());
				
				_isChanged |= (_aciklama != value); _aciklama = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual IList<PlanSoruTur> ListPlanSoruTur
		{
			get { return _listPlanSoruTur; }
			set { _isChanged |= (_listPlanSoruTur != value); _listPlanSoruTur = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual IList<Soru> ListSoru
		{
			get { return _listSoru; }
			set { _isChanged |= (_listSoru != value); _listSoru = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual IList<SoruTurHavuz> ListSoruTurHavuz
		{
			get { return _listSoruTurHavuz; }
			set { _isChanged |= (_listSoruTurHavuz != value); _listSoruTurHavuz = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual IList<SoruTurSoruSablon> ListSoruTurSoruSablon
		{
			get { return _listSoruTurSoruSablon; }
			set { _isChanged |= (_listSoruTurSoruSablon != value); _listSoruTurSoruSablon = value; }
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual IList<SoruTurZorlukAyar> ListSoruTurZorlukAyar
		{
			get { return _listSoruTurZorlukAyar; }
			set { _isChanged |= (_listSoruTurZorlukAyar != value); _listSoruTurZorlukAyar = value; }
		} 
	  
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public virtual bool IsChanged
		{
			get { return _isChanged; }
		}
		
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public virtual bool IsDeleted
		{
			get { return _isDeleted; }
		}
		
		#endregion 
		
		#region Public Functions

		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public virtual void MarkAsDeleted()
		{
			_isDeleted = true;
			_isChanged = true;
		}
		
		#endregion
		
		#region Equals And HashCode Overrides
		
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			SoruTur castObj = (SoruTur)obj; 
			return ( castObj != null ) &&
				( this._id == castObj.Id );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{ 
			int hash = 57; 
			hash = 27 * hash * this._id.GetHashCode();
					
			return hash;		
			
		}
		
		#endregion
		
	}
}