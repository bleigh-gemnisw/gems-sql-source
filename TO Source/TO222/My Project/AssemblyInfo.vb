' 6/04/18 Hide local disabled if not local forms active, show question 6
'10/30/18 Change Social Security numbers and Phone to masked text
' 1/10/19 Change print to enabled on new 
' 1/16/19 Add Control File value M59IN for last year M35H income import
' 1/31/19 EBC/FBC are only allowed if within state income limit
' 2/ 6/19 Add Control file value LEEL for East Lyme local
' 2/12/19 Change local tables to look at previous year
' 5/14/19 Move screen full exemption text boxes to left side to match print
'12/16/19 Change to generic grid, update screen and form to OPM 12/19
' 4/28/21 Fix Unmarried box for Milford Local form
' 1/ 5/22 Change TXMVDC to TXMVD
' 4/16/22 Always enable print button if not Milford
' 4/27/22 East Lyme: Fix missing Local Headings when denied, Save denied local
' 1/30/23 Change City/MCity to 25 chars, Limit first name/last name to field sizes on lookups
' 7/26/23 Change screen ("B" Code) to ("B" Code Used)
' 1/21/25 Fix Populate name & second name from assessor file
' 2/18/25 Local East Lyme: Don't look at chknonvet value since it's not visible
' 2/19/25 Local East Lyme: Show DAC also when disallowed
' 2/25/25 East Lyme: Allow printing forms when disallowed
' 3/26/25 Winchester Local form
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TO222")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain M59A Addl. Vets")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("c403557d-9c58-4e5f-b781-a3efcd190404")> 

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
