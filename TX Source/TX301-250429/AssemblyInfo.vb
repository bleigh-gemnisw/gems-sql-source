' 8/ 7/18 Write OID (Vehicle ID) to Invoice file
' 5/27/20 Copy All Banks logic to RealSewer
' 6/ 4/20 Change Webster scanline now includes sewer amounts
' 6/22/20 Change Heading CSV Name to Sewer Name 
' 7/30/20 Add Scanline for Real/Sewer (76)
'12/21/20 Change Ledyard default scanline to use Webster Types
'11/17/21 WAIT until Jan 2022: Remove Ledyard default scanline to use Webster Types
'12/ 5/22 Truncate loc to 25 chars
'12/ 6/22 Add Account ID to CSV file
'12/16/22 Supp: Trim oass compare to blank (space not same as blank)
' 6/ 6/23 Trim Code on Escrow compare (was not skipping)
' 6/ 9/23 Add Control Record CCRND logic
' 6/21/23 Fix WriteUBInvoice to use WrkTypeUB
' 7/31/24 January new millrate recalc tax: Only RE update taxt/tax2nd=taxt-tax1st/recalc elderly/local?/
'         Adjust BALD/ C/C file Adjust override
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
<Assembly: AssemblyProduct("Print Tax Bills")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("0115FEC3-3693-49C0-BB5C-71D4BB50C919")> 

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
