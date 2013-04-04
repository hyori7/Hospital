using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DataTier;
using System.Data;


namespace BusinessTier
{
	[DataObject(true)]
	public abstract class BaseCommand
	{
		

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public abstract DataTable select(Data data);

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public abstract bool insert(Data data);

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public abstract bool update(Data data);

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public abstract bool delete(Data data);

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public abstract Data list(Data data);

		
	}
}
