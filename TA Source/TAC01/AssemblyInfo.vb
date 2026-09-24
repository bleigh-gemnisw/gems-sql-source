' 1/30/18 Fix Coventry Exempt properties, Fix Salem Exempt properties
' 7/16/18 Disable Exemptions bridging
' 1/17/19 Add Gross to omitted report
' 3/ 5/19 Strip commas from Vision Name & Second Name
' 7/ 1/19 Strip / from Volume and Page
' 1/21/21 Move Cat/Exmpt add logic to within addonerecordp
' 1/25/21 Include Exempt update for East Lyme (Skip Exempt code)
' 1/28/21 Show message when Tax Category is changing
' 3/ 9/21 Coventry Exempt split Land/Building (2 buckets)
' 3/22/21 Split Exempt Property in Vision to Building and Land
' 3/23/21 Split Exempt Property in CLT Alternative to Building and Land
' 3/25/21 Only show Alert if Catagery is updated
' 4/ 5/21 Strip out dashes from assessment code
' 4/22/21 East Lyme fix All accounts changed to Exempt
' 6/ 2/21 INACTIVE Add VisionCO format, save c/o to second name (if blank)
'11/ 4/21 Expand Assessment & Exemptions to match Vision and show error when more than 7 used
'12/20/21 Convert edit to numeric when checking assessment codes
' 1/12/22 Trim field Cat on add
' 1/27/22 Change StreamReader to access as read (PP)
' 2/ 2/22 Change report title NOT in GEMS to Omitted from CAMA Bridge
' 2/ 3/22 Change add missing to update Name & Category only (was updating everything)
' 2/10/22 Change add missing to add tax exempt accounts only when Category is checked
' 3/28/22 CLT: populate Building and Land for Exempt
' 7/ 6/22 Only enable backup option when posting
' 7/25/22 Reorder screen checkboxes
'12/14/22 Add option for Admins
' 1/19/23 Right Justify Clocno
' 4/ 4/23 Admins: Fix City/State split
' 9/24/23 Coventry: Split Vol/Pge based on space position
' 2/ 4/25 Vision: Add Option for Owner of Record or Last Sales Owner
'MK 8/18/25 CheckDate: change low year from 1800 to 1600
'MK 9/23/26 ADD PHASE Control record for Phase In processing, Full=Vision - Original, REAL: Assessments = original + prorated FULL by phase in year
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TAC01")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Assessor Cama Bridge")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: ComVisible(False)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("0255D539-4521-448E-A9AB-CE84095738AD")> 

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






