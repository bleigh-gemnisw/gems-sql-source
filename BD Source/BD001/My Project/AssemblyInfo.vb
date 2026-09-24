' 5/15/18 Change approval date to save only when paid
' 8/ 6/18 Rework program to seperate permit screens (5 total)
' 8/14/18 RE Search by location was hidden, add Permit edits (payment required)
' 9/28/18 Add Change Permit Type
'10/19/18 Fix public show not returning to list types, move most edits to permit edits
'11/ 2/18 Add Credit Card payments
'12/19/18 Change lookup to TXREAL (was TXREALC)
' 1/10/19 Change "Tax" to "Text" Change Admendment
' 2/25/19 Add Project Description to Demo Permit
' 2/26/19 Add Demo fields to permit print
' 3/ 6/19 Set Dmstor to numeric in Print permit
' 4/24/19 uncomment deletedata (form C) 
' 8/28/19 Show contractor zip code message
' 5/ 3/21 Derby: Hard Code signature used based on approval date 
' 5/ 5/21 Derby: Use application date from correct permit type 
' 6/17/21 Derby: Hard Code another signature used based on approval date
'11/ 1/21 Replace TrueGrid
' 8/16/22 CheckBackTax when setting list#
'11/16/22 Write PRF to BDCON
'11/18/22 Update BDCON, getrecord before save after setting new coid
'11/22/22 Handle single quote in search
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("BD001")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain Building Dept Permits")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("cf96d1df-ef8b-456e-beb9-670cdf18b98e")> 

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
