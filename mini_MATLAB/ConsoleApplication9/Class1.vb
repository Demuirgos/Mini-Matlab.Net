Public Class function_OP
    Delegate Function f(ByVal x As Decimal) As Decimal
    Delegate Function f2(ByVal x As Decimal, t() As Decimal, i As Integer) As Decimal
    Delegate Function f_mv(ByVal a() As Decimal) As Decimal
    Public Shared Function integrate(ByVal g As f, a As Decimal, b As Decimal, n As Integer, Optional m As Integer = 3) As Decimal
        Dim c As Decimal = 0
        Dim h As Double = (b - a) / n
        Dim h2 As Double = 2 / m
        Dim x(0) As Decimal
        Dim t(0), w(0) As Decimal
        ReDim x(n), t(m), w(m)
        For i = 0 To n
            x(i) = a + i * h
        Next
        For i = 0 To m
            t(i) = -1 + i * h2
        Next
        For i = 0 To m
            w(i) = intgrl2(AddressOf lag, t, i)
        Next
        For i = 0 To n - 1
            For j = 0 To m
                c += ((x(i + 1) - x(i)) / 2) * w(j) * g(((x(i + 1) - x(i)) / 2) * t(j) + ((x(i + 1) + x(i)) / 2))
            Next
        Next
        Return c
    End Function
    Public Shared Function lag(x As Decimal, t() As Decimal, n As Integer) As Decimal
        Dim c As Decimal = 1
        For i = 0 To t.Length - 1
            If Not i = n Then
                c *= (x - t(i)) / (t(n) - t(i))
            End If
        Next
        Return c
    End Function
    Public Shared Function intgrl2(ByVal g As f2, t() As Decimal, n As Integer, Optional j As Integer = 3) As Decimal
        Dim c As Decimal
        Dim x(0) As Double
        Dim k As Integer = 10000 * (t.Length - 1)
        Dim h As Double = 2 / k
        ReDim x(k)
        For i = 0 To k
            x(i) = -1 + i * h
        Next
        If j = 1 Then
            For i = 0 To k - 1
                c += (h / 2) * (g((x(i) + x(i + 1)) / 2, t, n))
            Next
        ElseIf j = 2 Then
            For i = 0 To k - 1
                c += (h / 2) * (g(x(i), t, n) + g(x(i + 1), t, n))
            Next
        Else
            For i = 0 To k - 1
                c += (h / 6) * (g(x(i), t, n) + 4 * g((x(i) + x(i + 1)) / 2, t, n) + g(x(i + 1), t, n))
            Next
        End If
        Return c
    End Function
    Public Shared Function derive(ByVal g As f, x As Decimal, Optional n As Integer = 1) As Decimal
        Dim h As Decimal = 0.0000001
        If n = 0 Then
            Return g(x)
        Else
            Return (derive(g, x + h, n - 1) - derive(g, x - h, n - 1)) / (2 * h)
        End If
    End Function

    Public Shared Function derive(ByVal g As f_mv, x() As Decimal, m As Integer, Optional n As Integer = 1) As Decimal
        Dim h As Decimal = 1.0E+23
        Dim x_h() As Decimal
        x_h = x
        x_h(m) += 1 / h
        If n = 0 Then
            Return g(x)
        Else
            Return (derive(g, x_h, m, n - 1) - derive(g, x, m, n - 1)) * h
        End If
    End Function
    Public Shared Function segment(ByVal g As f, a As Decimal, b As Decimal, Optional n As Integer = 100) As Decimal
        Dim l As Decimal = 0
        Dim dl As f
        dl = Function(ByVal x As Decimal) As Decimal
                 Dim h As Decimal = 1 / Integer.MaxValue
                 If x + h > b Or x - h < a Then
                     Return 1
                 End If
                 Return Math.Sqrt(1 + Math.Pow(((g(x + h) - g(x)) / h), 2))
             End Function
        l = integrate(dl, a, b, n, 3)
        Return rnd(l, 7)
    End Function
    Public Shared Function img(ByVal g As f, x As Decimal) As Decimal
        Return g(x)
    End Function
    Private Shared Function rnd(a As Decimal, n As Integer)
        Return Math.Round(a * 10 ^ n) / 10 ^ n
    End Function
End Class