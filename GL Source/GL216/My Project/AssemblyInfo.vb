'12/28/18 Also check Expend<>0 or Encumb<>0
'10/25/19 Add double quotes to csv file for description fields (handle extra comma)
'10/28/19 Remove duplicate records in file
' 9/28/20 Add keypress filter for acct from/to fields
'10/20/20 Add option for Source 6 
'10/28/20 Add Dept & Fund Percentages to report
' 1/ 7/21 Add function selection
' 4/ 7/21 Fix typo "A P P R O P R I A T I O N"
' 4/15/21 Fix Page Break by Dept
' 2/ 1/22 Add Lookups for Object and Function
'11/ 8/22 Add option to select an account
' 3/ 9/23 Add option to hide dept headings
' 6/19/23 Remove Expend<>0 to be same as GL214
' 7/17/24 Change Report Zoom to 100
'10/17/24 Add Expend<>0 back in
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL216")> 
<Assembly: AssemblyDescription("Print Summary for Revenue/Expenses")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("4cd2ac91-0647-420d-af21-ae4e8af5ac12")> 

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
