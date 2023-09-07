module Tests.Homework5.ParserTests

open System
open Hw5
open Hw5.Calculator
open Hw5.Parser
open Microsoft.FSharp.Core
open Tests.RunLogic.Attributes
open Xunit

let epsilon: decimal = 0.001m
        
[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData(15, 5, CalculatorOperation.Plus, 20)>]
[<InlineData(15, 5, CalculatorOperation.Minus, 10)>]
[<InlineData(15, 5, CalculatorOperation.Multiply, 75)>]
[<InlineData(15, 5, CalculatorOperation.Divide, 3)>]
let ``ints parsed correctly`` (value1 : int, value2: int, operation, expectedValue : int) =
    //act
    let actual = Calculator.calculate value1 operation value2
    
    //assert
    Assert.Equal(expectedValue, actual)

[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``floats parsed correctly`` (value1 : float, value2: float, operation, expectedValue : float) =
    //act
    let actual = (abs (expectedValue - Calculator.calculate value1 operation value2))
    
    //assert
    Assert.True(actual |> decimal < epsilon)
    
[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``doubles parsed correctly`` (value1 : double, value2: double, operation, expectedValue : double) =
    //act
    let actual = (abs (expectedValue - Calculator.calculate value1 operation value2))
    
    //assert
    Assert.True(actual |> decimal < epsilon)
    
[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``decimals parsed correctly`` (value1 : decimal, value2: decimal, operation, expectedValue : decimal) =
    //act
    let actual = (abs (expectedValue - Calculator.calculate value1 operation value2))
    
    //assert
    Assert.True(actual < epsilon)
    
[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData("15", "+", "5", 20)>]
[<InlineData("15", "-", "5", 10)>]
[<InlineData("15", "*", "5", 75)>]
[<InlineData("15", "/", "5",  3)>]
[<InlineData("15.6", "+", "5.6", 21.2)>]
[<InlineData("15.6", "-", "5.6", 10)>]
[<InlineData("15.6", "*", "5.6", 87.36)>]
[<InlineData("15.6", "/", "5.6", 2.7857)>]
let ``values parsed correctly`` (value1, operation, value2, expectedValue) =
    //arrange
    let values = [|value1;operation;value2|]
    
    //act
    let result = parseCalcArguments values
    
    //assert
    match result with
    | Ok resultOk ->
        match resultOk with
        | arg1, operation, arg2 -> Assert.True((abs (expectedValue - Calculator.calculate arg1 operation arg2)) |> decimal < epsilon)
    | Error e -> raise (InvalidOperationException(e))
        
[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData("f", "+", "3")>]
[<InlineData("3", "+", "f")>]
[<InlineData("a", "+", "f")>]
let ``Incorrect values return Error`` (value1, operation, value2) =
    //arrange
    let args = [|value1;operation;value2|]
    
    //act
    let result = parseCalcArguments args
    
    //assert
    match result with
    | Ok _ -> raise (InvalidOperationException("This test must always return Error Result Type"))
    | Error resultError -> Assert.Equal(resultError, Message.WrongArgFormat)
    
[<Homework(Homeworks.HomeWork5)>]
let ``Incorrect operations return Error`` () =
    //arrange
    let args = [|"3";".";"4"|]
    
    //act
    let result = parseCalcArguments args
    
    //assert
    match result with
    | Ok _ -> raise (InvalidOperationException("This test must always return Error Result Type"))
    | Error resultError -> Assert.Equal(resultError, Message.WrongArgFormatOperation)
    
[<Homework(Homeworks.HomeWork5)>]
let ``Incorrect argument count throws ArgumentException`` () =
    //arrange
    let args = [|"3";"+";"4";"5"|]
    
    //act
    let result = parseCalcArguments args
    
    //assert
    match result with
    | Ok _ -> raise (InvalidOperationException("This test must always return Error Result Type"))
    | Error resultError -> Assert.Equal(resultError, Message.WrongArgLength)
    
[<Homework(Homeworks.HomeWork5)>]
let ``any / 0 -> Error(Message.DivideByZero)`` () =
    //arrange
    let args = [|"3";"/";"0"|]
    
    //act
    let result = parseCalcArguments args
    
    //assert
    match result with
    | Ok _ -> raise (InvalidOperationException("This test must always return Error Result Type"))
    | Error resultError -> Assert.Equal(resultError, Message.DivideByZero)

