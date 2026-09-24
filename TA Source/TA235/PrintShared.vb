Imports System.Text
Module PrintShared
Public ds As DataSet = New DataSet
Friend Sub BuildDS()
  Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("numre", Type.GetType("System.Int64"))
      .Columns.Add("numrefrz", Type.GetType("System.Int64"))
      .Columns.Add("numrest", Type.GetType("System.Int64"))
      .Columns.Add("numretot", Type.GetType("System.Int64"))
      .Columns.Add("nummv", Type.GetType("System.Int64"))
      .Columns.Add("numpp", Type.GetType("System.Int64"))
      .Columns.Add("num", Type.GetType("System.Int64"))
      .Columns.Add("numrex", Type.GetType("System.Int64"))
      .Columns.Add("numppx", Type.GetType("System.Int64"))
      .Columns.Add("nummvx", Type.GetType("System.Int64"))
      .Columns.Add("grossre", Type.GetType("System.Int64"))
      .Columns.Add("grossrefrz", Type.GetType("System.Int64"))
      .Columns.Add("grossrest", Type.GetType("System.Int64"))
      .Columns.Add("grossretot", Type.GetType("System.Int64"))
      .Columns.Add("grossmv", Type.GetType("System.Int64"))
      .Columns.Add("grosspp", Type.GetType("System.Int64"))
      .Columns.Add("gross", Type.GetType("System.Int64"))
      .Columns.Add("grossrex", Type.GetType("System.Int64"))
      .Columns.Add("grossppx", Type.GetType("System.Int64"))
      .Columns.Add("grossmvx", Type.GetType("System.Int64"))
      .Columns.Add("examre", Type.GetType("System.Int64"))
      .Columns.Add("examrefrz", Type.GetType("System.Int64"))
      .Columns.Add("examrest", Type.GetType("System.Int64"))
      .Columns.Add("examretot", Type.GetType("System.Int64"))
      .Columns.Add("exammv", Type.GetType("System.Int64"))
      .Columns.Add("exampp", Type.GetType("System.Int64"))
      .Columns.Add("exam", Type.GetType("System.Int64"))
      .Columns.Add("netre", Type.GetType("System.Int64"))
      .Columns.Add("netrefrz", Type.GetType("System.Int64"))
      .Columns.Add("netrest", Type.GetType("System.Int64"))
      .Columns.Add("netretot", Type.GetType("System.Int64"))
      .Columns.Add("netmv", Type.GetType("System.Int64"))
      .Columns.Add("netpp", Type.GetType("System.Int64"))
      .Columns.Add("net", Type.GetType("System.Int64"))
    End With
    ds.Tables.Add(myTable)
End Sub
Public Sub ClearSharedTotals()
End Sub
End Module






