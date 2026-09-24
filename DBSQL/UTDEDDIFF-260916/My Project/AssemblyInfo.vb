' 09/14/26 Ken - Added GetLatestAll for UB114 latest Account/Meter reporting.
'======================================================================
' UTDEDDIFF - Customer Meter/Deduct History data access
'
' 09/01/26 Ken - Initial creation for UB114 Customer Meter/Deduct History.
'                Provides SQL access to the UTDEDDIFF table.
'                Stores customer/account, meter number, date, reading, calculated
'                difference and reason code, including history lookup support.
' 09/01/26 Ken - Added next-reading lookup used by UB114 update validation.
' 09/01/26 Ken - Added Meter # as part of the record key.  All history, previous/
'                next reading, add/update/delete and recalc routines are now scoped
'                by Account + Meter.  Added delete support for UB114 toolbar Delete.
'======================================================================
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

<Assembly: AssemblyTitle("UTDEDDIFF")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("Gemni Software")>
<Assembly: AssemblyProduct("UTDEDDIFF")>
<Assembly: AssemblyCopyright("")>
<Assembly: AssemblyTrademark("")>
<Assembly: ComVisible(False)>
<Assembly: Guid("9b20d8c3-6c48-4c0a-9d79-341f93dc7e89")>
<Assembly: AssemblyVersion("1.0.*")>
