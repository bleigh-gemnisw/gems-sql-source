' 9/14/21 Add Interest Date
' 1/27/22 Change StreamReader to access as read
' 7/19/22 ALways use Receipt Date (was date in file if present)
'10/31/22 Only check date for Normal format
' 4/ 4/23 Normal: Strip out any slashes in date 
' 4/ 6/23 Add Custom format for Avon (Normal)
' 6/14/13 Add Custom format for Southington (Normal)
' 7/ 6/23 Avon: hard code Temporary format 
' 8/ 7/23 Avon: remove Temporary format
' 9/18/23 Normal: Change Ref to Alphanumeric (was numeric)
'6/12/25  kb added get bulk  goign to sql to get all txinv records to speed up pgm

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
<Assembly: AssemblyProduct("Load Web Receipts")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("6BAC1603-1EC0-4444-852E-0D4798D2C4BF")> 

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






