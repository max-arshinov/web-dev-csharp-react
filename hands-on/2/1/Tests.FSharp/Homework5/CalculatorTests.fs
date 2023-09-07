module Tests.Homework5.CalculatorTests

open Hw5.Calculator
open Microsoft.FSharp.Core
open Tests.RunLogic.Attributes
open Xunit

let epsilon: decimal = 0.001m
        
[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData(15, 5, CalculatorOperation.Plus, 20)>]
[<InlineData(15, 5, CalculatorOperation.Minus, 10)>]
[<InlineData(15, 5, CalculatorOperation.Multiply, 75)>]
[<InlineData(15, 5, CalculatorOperation.Divide, 3)>]
let ``+, -, *, / work return correct calculation results with ints`` (value1 : int, value2: int, operation, expectedValue : int) =
    //act
    let actual = calculate value1 operation value2
    
    //assert
    Assert.Equal(expectedValue, actual)

[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``+, -, *, / work return correct calculation results with floats``
    (value1 : float, value2: float, operation, expectedValue : float) =
    //act
    let actual = abs (expectedValue - calculate value1 operation value2)
        
    //assert
    Assert.True(actual |> decimal < epsilon)
    
[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``+, -, *, / work return correct calculation results with doubles``
    (value1 : double, value2: double, operation, expectedValue : double) =
    //act
    let actual = abs (expectedValue - calculate value1 operation value2)
    
    //assert
    Assert.True(actual |> decimal < epsilon)
    
[<HomeworkTheory(Homeworks.HomeWork5)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``+, -, *, / work return correct calculation results with decimals``
    (value1 : decimal, value2: decimal, operation, expectedValue : decimal) =
    //act
    let actual = abs (expectedValue - calculate value1 operation value2)
    
    //assert
    Assert.True(actual < epsilon)