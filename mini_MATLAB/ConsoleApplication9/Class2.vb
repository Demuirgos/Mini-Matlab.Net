Class matrix
    Public Sub New(Optional ByVal a(,) As Double = Nothing)
        M = a
    End Sub
    Public M(,) As Double
    Public Shared Operator *(ByVal M As matrix, ByVal N As matrix)
        Dim t As New matrix()

    End Operator
    Public Shared Operator +(ByVal M As matrix, ByVal N As matrix)
        Dim t As New matrix()
        For i = 0 To Math.Max(M.M.GetLength(1) - 1, N.M.GetLength(1) - 1)
            For j = 0 To Math.Max(M.M.GetLength(0) - 1, N.M.GetLength(0) - 1)
                If (Not M.M(i, j) = Nothing) And (Not N.M(i, j) = Nothing) Then
                    t.M(i, j) = M.M(i, j) + N.M(i, j)
                ElseIf (M.M(i, j) = Nothing) And (Not N.M(i, j) = Nothing) Then
                    t.M(i, j) = N.M(i, j)
                ElseIf (Not M.M(i, j) = Nothing) And (N.M(i, j) = Nothing) Then
                    t.M(i, j) = M.M(i, j)
                ElseIf (Not M.M(i, j) = Nothing) And (N.M(i, j) = Nothing) Then
                    Exit For
                End If
            Next
        Next
        Return t
    End Operator
End Class