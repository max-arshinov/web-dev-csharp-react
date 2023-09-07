module Hw5.Calculator

open System

type CalculatorOperation =
     | Plus = 0
     | Minus = 1
     | Multiply = 2
     | Divide = 3

[<Literal>] 
let plus = "+"

[<Literal>] 
let minus = "-"

[<Literal>] 
let multiply = "*"

[<Literal>] 
let divide = "/"

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline calculate value1 operation value2: 'a =
    (NotImplementedException() |> raise)