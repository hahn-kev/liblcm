## --------------------------------------------------------------------------------------------
## Copyright (c) 2006-2013 SIL International
## This software is licensed under the LGPL, version 2.1 or later
## (http://www.gnu.org/licenses/lgpl-2.1.html)
##
## NVelocity template file
## This file is used by the FdoGenerate task to generate the source code from the XMI
## database model.
## --------------------------------------------------------------------------------------------
//This is automatically generated by FDOGenerate task.  ****Do not edit****
using System;
using SIL.FieldWorks.Common.COMInterfaces;
using SIL.FieldWorks.Common.FwUtils;

namespace SIL.FieldWorks.FDO	// All generated class interfaces are in here.
{
	#region Interface for CmObject
	/// <summary>
	/// Interface for a CmObject.
	/// </summary>
	public partial interface ICmObject
	{
		/// <summary>
		/// Project-specific ID of the object.
		/// </summary>
		int Hvo
		{
			get;
		}

		/// <summary>
		/// Object owner. (Null, if not owned.)
		/// </summary>
		ICmObject Owner
		{
			get;
		}

		/// <summary>
		/// Field ID of the owning object where the object is stored.
		/// </summary>
		int OwningFlid
		{
			get;
		}

		/// <summary>
		/// Owning ord of the owning object where the object is stored.
		/// </summary>
		int OwnOrd
		{
			get;
		}

		/// <summary>
		/// Class ID of the object.
		/// </summary>
		int ClassID
		{
			get;
		}

		/// <summary>
		/// Unique ID of the object. If this will hang around, prefer to use the Id.
		/// </summary>
		Guid Guid
		{
			get;
		}
	}
	#endregion Interface for CmObject

#foreach($module in $fdogenerate.Modules)
	#foreach($class in $module.Classes)
		#if($class.Name != "CmObject")
			#parse("classInterface.vm.cs")
		#end
	#end
#end

}