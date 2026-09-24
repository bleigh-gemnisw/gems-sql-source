' 9/23/19 Add field RAMORT Amortization Calc (Blank use default)
'10/ 8/19 Change Simple Amort to handle fixed bond amount. Bond pct is for delq. bond interest. 
' 5/10/22 Change Bill<1=0 To Bill<0=0
'12/12/22 Add Meter Code D (Drop 2 highest then double)
' 1/27/25 Add User charges, Fix Markup Charge
'MK 11/24/25 Clear Out_ActualUse
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("A2868F83-507E-437C-ABA3-6558BDB08550")> 

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
