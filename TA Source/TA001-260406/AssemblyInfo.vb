' 1/22/18 Darien Local 10% net exemptions 
' 3/21/18 CalcBTR edit check changed from TotBTR>0 to TotBTR<>0
' 5/02/18 Add edit check: list# cannot be 0
' 5/10/18 Remove edit check: List# cannot be blank due to auto assign when 0
' 9/20/18 Add Before C/C message to RE/PP/MV screens
'10/22/18 Change Control File format
' 4/30/19 Show Before C/C Number and change lookup to Frozen File
' 5/ 1/19 Change log time to Miltary
'12/30/19 Change message text: Before C/C to Prior Yr Before C/C
' 1/10/20 Change screen text Residential to Domiciled (MV)
' 3/10/21 Write to MV Loc# and Loc fields
' 3/29/21 Keep Drop down selection when changeing type if applicable
'12/29/21 Fix issue with Back button in TA001DMV when cursor in Vehicle ID
' 8/ 1/22 Add Gross to Real Estate Searches
' 8/22/22 Add Gross/Value to PP, MV & Suppl Searches
' 8/25/22 Write out Original Log record, Fix Add using AutoGen
' 8/30/22 Can use Enter key to Find
'11/22/22 Handle single quote in all searches
' 5/22/23 Add Attachments: RE/PP by List#, MV/SU by Custid & Regno
' 7/28/23 Fix Attachment count (RE)
'10/12/23 Change calcass routine to use work field instead of txovalue when negative so they dont lose value on screen.    Only put message
'           Show error when you hit save button not on every key stroke.
' 5/ 8/24 Change message Prior Yr CC... to Before Bill C/C...
' 6/24/24 increase regno column in grid
'10/31/24 Add MSRP depreciation calc
'12/ 4/24 Add MV value rounding
'12/ 9/24 Add CalcExamAPA (RE: Hard code APA exemption to code 13, MV: exempt full value), RE: APA error check
'12/12/24 Remove version from licenses.licx 
'12/16/24 APA Exemption also includes code 15
' 1/ 2/25 Temporary: Hard Code depreciation year to 2024
' 1/17/25 MV FormLoad: Clear TxtOVMSRP before MSRP calc
'KB 5/16/25 add fields for dmv change for txsupp and also add domicile fields
'KB 5/16/25 add MSRP logic to this..
'KB 5/19/25    add RA2 addres line to supple
'kb 9/12/25   add ra2 address line to mv
'MK 9/22/25 Edit: Require source if MSRP is entered
'MK 10/27/25 Fix Credit Vehicle msrp, value and calc message 
'MK 10/29/25 Add Manual entry for Credit Vehicle
'MK 11/ 6/25 Add Clear Credit Vehicle option 
'MK 11/20/25 SUppl MV: Fix Override MSRP and refresh Gross, Credit, Exemptions and Net
'MK 11/25/25 Calc Depreciation year based on last Archive year + 1 
'MK  2/13/26 Remove APA edit check error
'MK  3/27/26 Comment TXPHIN fields removed
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("Gemni Software")>
<Assembly: AssemblyProduct("Tax Assessor Maintainence")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("5D37C654-A3A5-45B6-98F5-A126FDBC57F7")> 

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






