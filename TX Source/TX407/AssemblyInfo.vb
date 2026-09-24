' 2/21/18 Change Number of days to not clear secondary ID results before running primary ID
' 6/19/18 Fix Sync report (set Sel=true)
' 6/21/18 Putons flag by CustID (was Regno)
' 8/ 6/18 Fix puton flag
' 9/25/18 Add Chdate key to TXVEHL2, Use TXVEH if there is Vehid 
'10/19/18 Sync: Add Lease to DMV file for adds
' 4/23/19 Sync: Change Takeoff if no Flag (don't try to assign)
' 4/12/21 Add ECheck payment for web (Was Check)
' 4/26/21 Split out ECheck logic (was included with Check)
' 3/25/22 DMV File: Write N if lease is blank
'11/ 3/22 Add Report to Review Takeoffs
'11/ 9/22 Putons: Check OID for vehicle first then try custid's, update vehid if needed
' 8/ 9/23 Change puton from openqry to getqry
' 9/ 7/23 Putons: Add ilease='' to query (Omit records with a leasing code) *COMMENTED
' 1/14/25 temp: recomplied
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
<Assembly: AssemblyProduct("DMV Putons/Take Offs")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("7EFE3092-A6E5-4FCC-9920-CE1087F665AF")> 

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






