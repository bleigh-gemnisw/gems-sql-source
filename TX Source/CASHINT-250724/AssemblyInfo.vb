' 2/ 6/18 Change minimum interest to check grace date (was due date)
' 4/11/18 Fix interest for quarterly bill adjusted payment 
' 5/28/19 Add Out_FeePaid and Out_BondPaid 
' 7/ 3/19 Fix partial interest wrong after adjustment if previous period
' 4/21/20 Control File LOWIN: Hard code low interest 4/1/20 to 6/30/20 at 3%
' 5/14/20 Change Low interest to check Tperc (was WrkMonths)
' 2/ 5/21 Change Low interest dates (2/1/21 to 4/30/21)
' 4/12/21 Change web payment to ECheck (Was Check) 
'10/26/21 MV/SU: always use C/C add date 
' 3/ 3/22 Fix Fee Paid total (was adding only when there was interest)
'11/11/22 Set GracePeriod Flag for CC Add's and new prorates 
' 3/20/23 Refunds should work like adjustments
' 1/ 2/24 Control File CCDT: Use C/C date if orig Tax was paid, no interest for 30 days
' 6/21/24 add out properties for norfolk use onbalance due report tagged off delinquent reports
' 7/23/24 Add Defer fields and use them if active (ICODE=D)
' 5/19/25 Output Original Interest (Interest before min interest applied)
'MK 6/ 3/25 Control File CCDT: check for negative balance also
'MK 6/16/25 Check for any interest due for Minimum Interest
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Calculate Interest")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("491FEA44-EB06-48DC-B229-CF0DDB370009")> 

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
