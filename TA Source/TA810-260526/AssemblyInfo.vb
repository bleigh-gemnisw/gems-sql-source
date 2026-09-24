'10/22/18 Change Control File format
'10/23/18 Change previous years to look at Archive file then TXINV 
' 3/17/21 Change MV Exemption amounts to look at C/C fields (was regular fields),
'          Fix MV Reason Edit
' 3/22/21 Change MV Exemptions to prorate (reduce) based on sale month
' 6/ 1/21 Add Editchecks for no code with exemption amount, RE: show c/c exemption code
' 7/21/21 Add Icons for History, Printer Setup
'10/ 6/21 Replace TrueGrid
'11/22/22 Handle single quote in all searches
' 2/24/23 MV: Add Hyperlink for Sale Month
' 3/ 8/23 Make reports external
' 3/27/23 Add error if add (list#=0) and VIN already in file, Fix GetTXMVPCT month (was only working for code),
'          remove internal MV 004 report
' 4/ 4/23 Control Record CCRND=Y for rounding Prorate to 10
' 5/10/23 Change Duplicate VIN error to a warning
' 5/ 2/24 Add Attachments
' 5/28/24 MV Sale Pct: Bypass Format with decimals if percent is 0
' 6/12/24 Don't overwite exemption code from C/C is there is no regular exemption
'11/13/24 Change VIN to max 17 chars 
'11/21/24 MV: Use TXINV mvyr (was year)
'12/13/24 increase size of cdesc from 25 to 50 
'MK 4/30/25 Add MSRP fields to MV screen (Files TXMSRP/TXMSRPDEP/TXMSRPCD/TXMCTL), Add PriceDigest API
'MK 5/13/25 Add MSRP to report
'MK 5/14/25 Fix Duplicate VIN warning
'MK 7/24/25 Create new form for Supp MV (TA8105R) 
'ken 9/12/25 - add domicile fields to MV and supple...  need to know about TXVCUS  what is it. and also txinv fields
'ken 9/25/25 - stretch out regno field on MV and SU screen si all 8 digits fit
'ken 9/25/25 - add MV CR reprot (like TA811) 
'MK 9/26/25 Add Supp GL Year and change it based on current month 
'ken 9/26/25 stretch our cred veh reg no on supple screen
'MK 11/10/25 Write Suppl MV month codes to TXCOEB (Purch/Save/Credit) 
'MK  2/12/26 Change Hard Coded year to Tax Year in CalcValue
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("Gemni Software")>
<Assembly: AssemblyProduct("Before Bill C/C Maintainence")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("5EBEC1BA-7579-4E70-9BFE-4D69700F47AC")> 

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






