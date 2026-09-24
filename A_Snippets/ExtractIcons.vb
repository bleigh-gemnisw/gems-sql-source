Module Module1
  Public Sub Extract()
    ' .Net Code        
    Dim img As Image
    img = MyFrmTA001.ImageList1.Images.Item(8)
    img.Save("C:\Icon1.png")
  End Sub
End Module
