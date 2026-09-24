' 2/28/18 Add Log files
' 7/10/18 Add EDU1 control file value for Metered (GNET)
' 7/19/18 Add EDU1 control file value for Usage (GNET)
' 3/26/19 Add Meter Reading Reason to grid
' 5/ 1/19 Change log time to Miltary
' 5/21/19 Prevent blank records to log files (UTAS/UTUS) 
' 9/24/19 hide extra columns in UTRATEAS
' 4/21/21 Fix Location next
' 6/ 2/21 Fix Name & Location Next
' 6/29/22 Remove Previous, Fix Next 
'11/22/22 Handle single quote in all searches
'12/12/22 Add meter Code D
' 7/31/23 Payoff2 screen didn't show Bond Interest amount
' 4/10/24 Fix Usage Calc fixtures not working
' 5/28/24 Change Rate code edit to trim spaces
' 6/12/24 Allow Units to be changed on meter screen (was label)
'11/ 1/24 Set reading date to last meter reading on meter screen
' 1/27/25 Add Metered user charges, Add link to show Meter bill Calc
' 6/10/25 KB   - added search by Route
'MK 7/17/25 Add Inactive checkbox
'MK 9/10/25 Meter must have a meter code to calulate a bill amount
'ken 9-18-25 added attachment feature
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Customer Master Maintainence")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("EA28CAC2-1467-4B78-81D9-A94594DED0A0")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:

<Assembly: AssemblyVersion("1.0.*")> 
