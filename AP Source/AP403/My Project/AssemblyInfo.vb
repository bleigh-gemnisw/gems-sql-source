' 5/16/19 Change check count to distinct count on PrtAP403B
' 9/16/20 Update VendorL1 for Suspended (True)
' 4/ 1/21 Clear WrkAmount to fix refresh issue
' 6/15/21 Remove TrueGrid code
' 9/ 8/21 Show error for Negative Checks and hide all other reports
' 2/22/22 Add Edit: Check number already used (in last 3 years)
' 6/23/22 ListVendor: Add Vendor address fields to datagrid
' 8/ 1/22 ListVendor: Hide susp column
'12/ 7/22 Cash account: Use APEBNK account if there else use GLFUND Cash Account
' 3/ 6/24 Add Control record APMCK to show manual check button (default=hide button)
'7/17/24  increase vendor name
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("AP403")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Print A/P Checks")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("324233ed-d5d1-4346-accb-b1281543b9f0")> 

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
