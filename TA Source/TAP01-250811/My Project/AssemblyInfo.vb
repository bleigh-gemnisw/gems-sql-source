' 9/12/18 Set list# to be 1st field in tab order
'10/09/18 Make email fields normal casing
'10/10/18 Trim Phone & fax from get last year 
'10/24/18 When checked, comment only printed if there were Depreciation codes. Change to always print.
'10/25/18 Add system value DCCMT to set Print Comments default to Y
'11/28/18 Add DBA search, fix scan
' 5/30/19 Add Status & Filing Status to summary report
' 9/ 1/21 Add Owner Name to various screens
'11/ 8/21 Fix Find/Prev (Add set blocking)
' 8/22/22 ListPprp: Value added so hide it
'10/ 4/22 Correct comment to 50 length (was 60)
'11/ 4/22 Don't write out 13 zero value, skip TXDCSUM add if code already there
'11/22/22 Handle single quote in all searches
' 1/26/23 TAP01B: Do not allow updates in Datagrid
' 7/17/23 Add Attachments
' 7/28/23 Fix Attachment Count
'10/23/23 Fix OWNTYP Partnership & BUSCAT Wholesale (was not saving)
'11/29/23 fix verbage for name and address on the lessor and lessee maint screens   
'10/25/24 Add IRS Business Activity Code, Change MV to MSRP and calc value
'10/31/24 Add PriceDigest API, Upgrade TrueGrid to 4.8
'11/18/24 IRSBUS needed cnvsng, Add Value back to screen (MSRP or Value)
'12/ 4/24 Check year matches to PriceDigest otherwise it's an error
' 1/ 2/25 Temporary: Hard Code depreciation year to 2024
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TAP01")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain PP Declarations")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("185fe872-997a-41ed-a292-47b202758648")> 

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
