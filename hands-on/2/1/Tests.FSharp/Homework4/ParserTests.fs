module Tests.Homework4.ParserTests

open System
open Hw4.Calculator
open Hw4.Parser
open Tests.RunLogic.Attributes
open Xunit
        
[<HomeworkTheory(Homeworks.HomeWork4)>]
[<InlineData("+", CalculatorOperation.Plus)>]
[<InlineData("-", CalculatorOperation.Minus)>]
[<InlineData("*", CalculatorOperation.Multiply)>]
[<InlineData("/", CalculatorOperation.Divide)>]
let ``+, -, *, / parsed correctly`` (operation, operationExpected) =
    //arrange
    let args = [|"15";operation;"5"|]
   
    //act
    let options = parseCalcArguments args
    
    //assert
    Assert.Equal(15.0, options.arg1)
    Assert.Equal(operationExpected, options.operation)
    Assert.Equal(5.0, options.arg2); 
    
[<HomeworkTheory(Homeworks.HomeWork4)>]
[<InlineData("f", "+", "3")>]
[<InlineData("3", "+", "f")>]
[<InlineData("a", "+", "f")>]
let ``Incorrect values throw ArgumentException`` (val1, operation, val2) =
    // arrange
    let args = [|val1;operation;val2|]
    
    // act/assert
    Assert.Throws<ArgumentException>(fun () -> parseCalcArguments args |> ignore)

[<Homework(Homeworks.HomeWork4)>]
let ``Incorrect operations throw ArgumentException``() =
    // arrange
    let args = [|"3";".";"4"|]
    
    // act/assert
    Assert.Throws<ArgumentException>(fun () -> parseCalcArguments args |> ignore)

[<Homework(Homeworks.HomeWork4)>]
let ``Incorrect argument count throws ArgumentException``() =
    // arrange
    let args = [|"3"; "."; "4"; "5"|]
    
    // act/assert
    Assert.Throws<ArgumentException>(fun () -> parseCalcArguments args |> ignore)