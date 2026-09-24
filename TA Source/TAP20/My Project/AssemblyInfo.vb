' 8/ 8/18 Include zero value accounts with Missing 
'11/29/18 Add update option for MV Loc 
'12/17/18 Add TXPPRP backup option
'12/28/18 Update MV form will use regular fields if MV field is blank
' 2/27/19 Split Post/Update into 2 questions
'11/20/20 Fix State not updating (Mailing/MV Address)
'12/20/21 Change Totals to omit Inactive records
' 6/21/22 TXPPRP Update: If exemption is 10 million or higher make it 0
'10/ 4/22 Add option to update (overwrite) comments
'11/ 2/22 Fix Updating Comments: Change ds name, start at seq 1, trim last comment to prevent blank record
' 1/31/24 TXPPRP Update: Include Zero amounts if checked to posting logic
' 2/13/25 Change missing PP decl from ass1=0 to owner name is blank
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TAP20")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("Update Personal Property File")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("1e5bb808-55e3-48a6-accc-80fca01dcb6a")> 

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

