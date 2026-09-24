' 7/05/18 Split out suspense refunds, add suspense refunds to audit refunds
'10/26/20 Clear OverCredit in cleartotals (was at start)
' 8/ 2/22 FrmCrViewer: Add Minimize button and also minimize program
' 4/ 5/23 Add a CloseRange before Exit Do
' 7/14/23 Add Export Detail File
'10/ 4/23 Add Phase
'11/21/24 PrevCCTax would not get populated if no C/C record
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
<Assembly: AssemblyProduct("Balance Sheet Report")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("F99A22EB-C4A7-4DF3-9CC9-2DE4567075EC")> 

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
