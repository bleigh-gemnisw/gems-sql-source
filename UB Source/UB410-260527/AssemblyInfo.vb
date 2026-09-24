' 7/ 1/24 Kensington: Format Bills & rate calc descriptions, Download rate calc descriptions
' 8/ 7/24 Fix Due Date/Grace Date on bill
' 8/29/24 Code/Format Kensington Fireline Bill
' 1/27/25 Add Meter User Charges to report
' 3/13/25 Add Billamtc to dsbill
'MK 7/17/25 Skip Inactive Accounts (Meter/Usage)
'MK 8/25/25 Add Subroutine Calcinterest_219SW 
'MK 9/10/25 Only CalcBill if there is a meter code for the type 
'MK 11/24/25 Write UTBLHS with bill split out and set date to interest date, add user charge (report) to BillAmtC
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("Gemni Software")>
<Assembly: AssemblyProduct("Print Combined Bills/Report")>
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("F7B04D9E-6671-4D38-A254-DC44B6FFF557")> 

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






