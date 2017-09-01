## --------------------------------------------------------------------------------------------
## Copyright (c) 2006-2013 SIL International
## This software is licensed under the LGPL, version 2.1 or later
## (http://www.gnu.org/licenses/lgpl-2.1.html)
##
## NVelocity template file
## This file is used by the LcmGenerate task to generate the source code from the XMI
## database model.
## --------------------------------------------------------------------------------------------
//This is automatically generated by LcmGenerate task.  ****Do not edit****
namespace SIL.LCModel	// All generated factory interfaces are in here.
{
	#foreach($module in $lcmgenerate.Modules)
	#foreach($class in $module.Classes)
		#if(!$class.IsAbstract)
			#parse("factoryInterface.vm.cs")
		#end
	#end
#end

}