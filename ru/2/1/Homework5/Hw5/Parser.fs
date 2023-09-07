module Hw5.Parser

open System
open Hw5.Calculator

let isArgLengthSupported (args:string[]): Result<'a,'b> =
    (NotImplementedException() |> raise)
    
[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline isOperationSupported (arg1, operation, arg2): Result<('a * CalculatorOperation * 'b), Message> =
    (NotImplementedException() |> raise)

let parseArgs (args: string[]): Result<('a * CalculatorOperation * 'b), Message> =
    (NotImplementedException() |> raise)    

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline isDividingByZero (arg1, operation, arg2): Result<('a * CalculatorOperation * 'b), Message> =
    (NotImplementedException() |> raise)       
    
let parseCalcArguments (args: string[]): Result<'a, 'b> =
    (NotImplementedException() |> raise)    