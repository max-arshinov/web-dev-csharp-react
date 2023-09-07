module Hw4.Parser

open System
open Hw4.Calculator


type CalcOptions = {
    arg1: float
    arg2: float
    operation: CalculatorOperation
}

let isArgLengthSupported (args : string[]) =
    NotImplementedException() |> raise

let parseOperation (arg : string) =
    NotImplementedException() |> raise
    
let parseCalcArguments(args : string[]) =
    NotImplementedException() |> raise
