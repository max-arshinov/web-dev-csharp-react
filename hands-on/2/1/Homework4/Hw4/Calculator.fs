module Hw4.Calculator

open System

type CalculatorOperation =
     | Plus = 0
     | Minus = 1
     | Multiply = 2
     | Divide = 3
     | Undefined = 4
     
let calculate (value1 : float) (operation : CalculatorOperation) (value2 : float) =
    NotImplementedException() |> raise
    
