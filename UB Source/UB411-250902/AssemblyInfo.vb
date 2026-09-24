' 5/02/18 Add Update Previous Adjustments (UTCOEA)
' 6/05/18 Add Back Tax Amount to Bill file
' 6/26/18 Add Name & Address to CSV File (Seperate fields)
' 7/10/18 Add EDU1 control file value for Metered (GNET)
' 7/10/18 Add Charge breakdowns to billing csv file
' 7/19/18 Add EDU1 control file value for Usage (GNET)
' 8/15/18 Add EDUs, Charge Per EDU, Rate Code to billing CSV file
' 8/23/18 Write Units to export files for metered family
'10/17/18 Add UBBNK, Write RE Bank Code to CSV bill file & Invoice file (GNET)
' 1/29/19 Add Fixture amount, Charge per fixture to CSV bill file
' 3/19/19 Add Account ID to billing csv file
' 4/23/19 Add Number of Fixtures to billing csv file
' 6/24/21 Add Fund to billing csv file
'10/20/21 CSV File: Add DelqFees to DelqLien
' 1/10/23 Add Ratecode to report (meter)
' 2/22/23 CSV File: Add 3rd & 4th readings, rate code charge, breakout 7
' 3/ 8/23 Pass EDU rate to TPAYMENT as 1st payment
' 9/20/23 Change Annual 2nd Half to return balance due (was 2nd payment)
' 6/17/24 Trim spaces from Type 
' 6/20/24 Add Units to meter billing report, add rate desc & calc to bill file
' 6/25/24 Norfolk: Change Rate Descriptions (S1 & S2 are now the same calc)
' 7/ 3/24 Norfolk csv: Add 2nd Total Due
' 9/16/24 Add Annual 2nd Half Posted option
' 1/27/25 Add Meter User Charges
' 4/23/25 Download CSV: Flip Usage Markup/EDU buckets 5 & 6
'MK 7/17/25 Skip Inactive Accounts (Meter/Usage)
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
<Assembly: AssemblyProduct("Print Bills/Report")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("F7B04D9E-6671-4D38-A254-DC44B6FFF557")> 

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






