using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model.Attributes
{
	class ForeignKeyAttribute : Attribute
	{
		public ForeignKeyAttribute(Type referencedClass)
		{
			ReferencedClass = referencedClass;
		}

		public Type ReferencedClass { get; set; }
	}
}
