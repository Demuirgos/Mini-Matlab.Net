Imports ConsoleApplication9.function_OP
Imports System.Math
Module Module1
    Function defcercle(x As Decimal) As Decimal
        'If x > 1 Then x = 1
        Return Sqrt(1 - Math.Pow(x, 2))
    End Function
    Function test(x As Decimal) As Decimal
        Return x*x
    End Function
    Sub main_p()
        Dim n As Decimal = 10
        Dim k As Decimal = 1
        Dim x As Decimal = 0
        While (True)
            Dim p1 As Decimal = 0
            Dim p2 As Decimal = 0
            Dim p3 As Decimal = 0
            p3 = function_OP.derive(AddressOf test, Math.PI, 1)
            p1 = 2 * function_OP.integrate(AddressOf defcercle, -1, 1, n, 3)
            p2 = function_OP.segment(AddressOf test, 0, 1, n)
            Console.Write("seg = " & p2 & " " & Sqrt(2) & vbNewLine)
            n += 1000000
        End While
        Console.Read()
    End Sub
    Sub main()
        main_p()
    End Sub

End Module
