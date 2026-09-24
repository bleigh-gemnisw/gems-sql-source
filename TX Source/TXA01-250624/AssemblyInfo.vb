' 3/26/18 Flip Year and type headings in Detail Grid
' 9/19/18 Write Recid to history
' 4/28/21 Replace TrueGrid
' 7/30/21 Set WrkAddMode to false on update
' 8/19/21 Fix Print edits when enter key pressed (was any key)
' 9/14/21 Add Interest Date (use strdt in BCHHDR), Change remove MV back tax flag to custid
' 9/16/21 Remove Exit sub in Remove previous year Back Tax
'10/31/22 Fix BALD on reports (change TCRBCH to TCRBCHL1)
' 1/29/23 Add Status for Incomplete batch
' 2/ 6/23 Fix posting to bond interest (TBATCHL1)
' 4/ 5/23 Add a CloseRange before Exit Do
' 7/20/23 Add Tran Number Fund, Add trnbr parm to GetViewbyBatch 
' 8/22/23 Add Leasing Batch Type(G), change to dropdown
'10/ 6/23 Fix Web Payments batch type, Enable controls when closing New screen
'11/30/23 Handle Bond Interest adjustments and refunds. If Bond Paid is more than Bond then change it to Bond.
'MK 6/ 4/24 Change Lien clear to also check that BALD<=0
'MK 6/ 5/25 Change updates to faster processing 
'MK 6/24/25 Fix update syntax for previous year back tax update
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
<Assembly: AssemblyProduct("Edit/Post Electronic Receipts")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("4DFEF7D3-7A86-42CD-9C07-4C4C7DC24990")> 

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






