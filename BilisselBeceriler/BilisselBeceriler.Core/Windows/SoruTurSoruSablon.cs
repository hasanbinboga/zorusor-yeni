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
	public class SoruTurSoruSablon 
	{
		#region Private Members
		
		// Variabili di stato
		private bool _isChanged;
		private bool _isDeleted;

		// Primary Key(s) 
		private long _id; 
		
		// Foreign Keys mappate come Many-To-One 
		private SoruTur _soruturref; 
		private SoruSablon _sorusablonref; 
		
		// Properties 
		private string _soruturaciklama; 
		
		// One-to-many relations 
		private IList<BelgePlanSoruTur> _listBelgePlanSoruTur;		

		#endregion
		
		#region Default ( Empty ) Class Constructor
		
		/// <summary>
		/// default constructor
		/// </summary>
		public SoruTurSoruSablon()
		{
			_id = 0; 
			_soruturref = null; 
			_sorusablonref = null; 
			_soruturaciklama = null; 
			_listBelgePlanSoruTur = null; 
		}
		
		#endregion // End of Default ( Empty ) Class Constructor
		
		#region Full Constructor
		
		/// <summary>
		/// full constructor
		/// </summary>
		public SoruTurSoruSablon(long id, SoruTur soruturref, SoruSablon sorusablonref, string soruturaciklama)
		{
			_id = id; 
			_soruturref = soruturref; 
			_sorusablonref = sorusablonref; 
			_soruturaciklama = soruturaciklama; 
			_listBelgePlanSoruTur = null; 
		}
		
		#endregion // End Full Constructor
		
		#region Required Fields Only Constructor
		
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public SoruTurSoruSablon(long id, SoruTur soruturref, SoruSablon sorusablonref)
		{
			_id = id; 
			_soruturref = soruturref; 
			_sorusablonref = sorusablonref; 
			_soruturaciklama = null; 
			_listBelgePlanSoruTur = null; 
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
		/// İlgili Soru Türünün Id si
		/// </summary>		
		public virtual SoruTur SoruTurRef
		{
			get { return _soruturref; }
			set { _isChanged |= (_soruturref != value); _soruturref = value; }
		} 
	  
		/// <summary>
		/// İlgili Soru Şablonunun Id si
		/// </summary>		
		public virtual SoruSablon SoruSablonRef
		{
			get { return _sorusablonref; }
			set { _isChanged |= (_sorusablonref != value); _sorusablonref = value; }
		} 
	  
		/// <summary>
		/// Şablonda, soru türü ile ilgili olarak yer alması istenen açıklama veya soru metninin yer aldığı alandır. Böylece aynı şablonda farklı sorular için farklı soru türlerine destek vermek mümkün olur.
		/// </summary>		
		public virtual string SoruTurAciklama
		{
			get { return _soruturaciklama; }
			set	
			{
				if ( value != null )
					if( value.Length > 2147483647)
						throw new ArgumentOutOfRangeException("Invalid value for SoruTurAciklama", value, value.ToString());
				
				_isChanged |= (_soruturaciklama != value); _soruturaciklama = value;
			}
		} 
	  
		/// <summary>
		/// 
		/// </summary>		
		public virtual IList<BelgePlanSoruTur> ListBelgePlanSoruTur
		{
			get { return _listBelgePlanSoruTur; }
			set { _isChanged |= (_listBelgePlanSoruTur != value); _listBelgePlanSoruTur = value; }
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
			SoruTurSoruSablon castObj = (SoruTurSoruSablon)obj; 
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