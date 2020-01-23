Imports ConsoleApplication9.function_OP
Imports System.Math
Module Module1
    Function read_f(s As String)
        Dim id(0, 0) As Integer
        ReDim id(s.Length / 2, 2)
        Dim k() As Integer = {0, 0}
    End Function

    Sub Main_e()
        Dim n As Integer = 2
        While (Not n = Integer.MaxValue)
            Dim e As Decimal = 0
            Dim x As Decimal = 0
            Dim f = Function(a As Integer) As Decimal
                        If a = 0 Then
                            Return 1
                        Else
                            Dim t As Integer
                            For i = 1 To a
                                t *= i
                            Next
                            Return t
                        End If
                    End Function
            For i = 0 To n
                x += Math.Pow(1, i) / f(i)
            Next
                        For i = 0 To n
                            e = Math.Pow(1 + 1 / n, n)
                        Next
                        n += 1
                        Console.Write(e & " " & x & " ratio" & x / e & vbNewLine)
        End While
        Console.Read()
    End Sub
    Function defcercle(x As Decimal) As Decimal
        'If x > 1 Then x = 1
        Return Sqrt(1 - Math.Pow(x, 2))
    End Function
    Function test(x As Decimal) As Decimal
        Return x
    End Function
    Function parsed(s as string) as Decimal
        
    End Function
    Sub main_p()
        Dim n As Decimal = 10
        Dim k As Decimal = 1
        Dim x As Decimal = 0
        While (True)
            Dim p1 As Decimal = 0
            Dim p2 As Decimal = 0
            Dim p3 As Decimal = 0
            'p3 = function_OP.derive(AddressOf test, Math.PI, 1)
            'p1 = 2 * function_OP.integrate(AddressOf defcercle, -1, 1, n, 3)
            p2 = function_OP.segment(AddressOf test, 0, 1, n)
            Console.Write("seg = " & p2 & " " & Sqrt(2) & vbNewLine)
            n += 1000000
        End While
        Console.Read()
    End Sub
    Function e(x() As Decimal) As Decimal
        Return x(0) * x(0) * x(0)
    End Function
    Function g(x As Decimal) As Decimal
        Return (x * x * x)
    End Function
    Sub main()
        main_p()
    End Sub

End Module
