Imports System.IO
Public Class Form1
    Dim sw As New StreamWriter("out.txt")
    Dim sr As New StreamReader("in.txt")

    Sub check()
        Dim str As String = sr.ReadLine
        str = str.Replace(")", "")
        str = str.Replace("(", "")
        Dim m() As String = Split(str, " ")
        Dim L(UBound(m)), H(UBound(m)), R(UBound(m)) As Integer
        For i = 0 To UBound(m)

            Dim m2() As String = Split(m(i), ",")
            L(i) = m2(0) : H(i) = m2(1) : R(i) = m2(2)
        Next
        Dim RMax As Integer
        For i = 0 To UBound(R)
            If R(i) > RMax Then RMax = R(i)
        Next
        Dim a As New ArrayList
        Dim th(RMax) As Integer
        For i = 0 To RMax
            Dim tmax As Integer
            tmax = 0
            For j = 0 To UBound(m)
                If L(j) <= i And R(j) >= i + 1 And H(j) > tmax Then
                    tmax = H(j)
                End If
            Next
            th(i) = tmax
        Next
        Dim Hei As Integer
        For i = 0 To RMax
            If th(i) <> Hei Then
                Hei = th(i)
                a.Add(i) : a.Add(Hei)
            End If

        Next
        Dim ans As String = Join(a.ToArray, ",")
        sw.WriteLine(ans)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        check()
        sw.Flush() : End
    End Sub

  
End Class
