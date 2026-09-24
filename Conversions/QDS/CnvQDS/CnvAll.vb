Module CnvAll
  'All Variables
  Public Const cAssPct As Decimal = 0.7 'MV Assessment Percentage of value
  Public Const cClassicVehicle As Integer = 500 'MV class 25 Minimim Value 
  Public Const cMinValue As Integer = 200 'MV all other classes Minimum value
  Public Const cReadCode As String = "CM" '1st Meter reading WT_ID to use
  Public Const cReadCode2 As String = "DM" '2nd Meter reading WT_ID to use
  Public Const cReadCode3 As String = "M" '3rd Meter reading WT_ID to use
  Public Const cRateOmit As String = "NON" 'Meter rate plan_code to omit
  Public Const cAssmntCode As String = "SA" 'TAXMAST Sewer Assessment plan code
  Public Const cOldYearHist As Integer = 2007 'Oldest history year to convert (not assessment)
  Public Const cArchiveOldYear As Integer = 2021 'Oldest archive year to convert 
  Public Const cArchiveNewYear As Integer = 2022 'Newest archive year to convert 
  Public Const cElderlyYear As Integer = 2020 'Oldest M35H/M59A year to convert 
End Module
