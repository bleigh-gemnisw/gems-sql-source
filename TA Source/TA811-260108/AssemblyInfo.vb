'10/22/18 Change Control File format
' 8/20/19 If printer is not blank then if copies=0 don't reset to 1
'10/ 8/19 Write Credit Vehicle fields (Suppl) 
'10/28/19 Convert Credit Vehicle Class to numeric  (Suppl)
' 3/22/21 Change MV Exemptions to prorate (reduce) based on sale month
'10/ 6/21 Replace TrueGrid 
'11/22/22 Handle single quote in all searches
' 3/ 8/23 Make reports external
' 4/ 4/23 Control Record CCRND=Y for rounding Prorate to 10
' 5/25/23 Add Attachments
' 7/19/23 If Before CC then get Sale Code
' 8/24/23 Add In_Nosbil parm to TPAYMNT (skip single bill calc)
' 8/29/23 Add In_Nosbil parm to TPAYMNT (lblnewamt)
' 9/ 7/23 Comment In_NoSbill (needs futher review) 
' 9/20/23 added flag for the NoSbill  using GNET control file  (key = NOSB)  public var is   MyNosb
' 9/29/23 MV: Only use Before CC ass code if there is no after bill cc
'10/13/23 MV: Only use original cc ass code in addmode
'10/16/23 MV: Don't bring in exemption codes from original C/C
'12/20/23 In_NoSbill: Flag only works for updates. Adds will use normal split.
' 8/28/24 Fix winsted split when amount is reduced
'12/13/24 increase cdesc from 25 to 50
'12/16/24 add back in comment routine for taxcom   L/Y/T 
' 1/15/25 Tpaymnt: remove in_tax1 from PP
' 2/12/25 Adjust original assessment amounts by BTR amounts (RE & PP) if no previous C/C
'MK  7/ 1/25 Add MSRP fields to MV screen (Files TXMSRP/TXMSRPDEP/TXMSRPCD/TXMCTL), Add PriceDigest API 
'MK  7/14/25 Don't replace Assmnt during form load in TXTOVMSRP textchanged event
'MK 12/29/25 Add MSRP & PriceDigest code
'TO DO: MV/Supp Change hard coded MSRP Depreciation year (2024)
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
<Assembly: AssemblyProduct("After Bill C/C Maintainence")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("E3145B36-0DA1-4597-AE2C-0C47A1EB4070")> 

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






