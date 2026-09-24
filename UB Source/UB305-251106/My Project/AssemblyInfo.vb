' 7/31/19 Add Previous Reading to routes file
'10/ 9/19 Change list# position in get readings
' 3/24/21 Change to write reading to file if same reading
' 3/31/21 Check Error Code, skip if there is one and add to error list
' 1/27/22 Change StreamReader to access as read
'11/28/23 Add EZRoute File 1.4 format
' 3/25/24 Legacy format no longer used, Route is numeric, Change location position
' 3/27/24 Move Meter size/multiplier code to readings
' 6/18/24 Adjust Create Readings EZRoute File 1.4 format, Write Meter Size Description instead of Meter Size Code
' 6/24/24 EZRoute: Set dials to 6
'10/ 2/24 Lower reading message was getting overlayed
'12/19/24 Rename program description from EzRoute to Neptune, PRMDT: Write Route (Kensington) instead of list
' 3/ 3/25 Worthington uses Legacy Format
' 4/ 3/25 Change 1.4 format to add route header/footer for each route (Kensington has 3)
' 4/23/25 Hard Code 4 dials for Kensington
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("UB305")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Interface to EZRoute")> 
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

