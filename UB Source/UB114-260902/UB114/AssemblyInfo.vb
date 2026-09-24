'======================================================================
' UB114 - Customer Meter/Deduct History
'
' 09/01/26 Ken - Initial UB114 created from the UB107 program shell.
'                Maintains standalone customer meter/deduct reading history.
'                Uses UTDEDDIFF for dated readings and calculated differences.
'                Reading history grid displays Date, Reading, Difference and Reason.
'                Difference is calculated from the previous reading by date.
'                Existing entries may be loaded from the grid and updated.
' 09/01/26 Ken - Added reading sequence validation and corrected ErrorProvider
'                clearing after a validation error is corrected.
' 09/01/26 Ken - Added Meter # search using the UB102B UTCUSTL1 meter lookup.
'                UTDEDDIFF history is keyed by Account + Meter + Date.
'                Date is locked on update; duplicate Account/Meter/Date is blocked.
'                Older dated readings may be added.  A reading must remain between
'                the previous and following reading when those records exist.
' 09/01/26 Ken - Added UB102-style toolbar Delete action.  Differences are now
'                recalculated automatically after add, update and delete, so the
'                manual Recalc Difference option was removed.
'======================================================================
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
<Assembly: AssemblyProduct("Customer METER/DEDUCT")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("18BE23AE-FB1A-4AC2-8F01-732E1E8B48CF")> 

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






