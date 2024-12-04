module Tests_RomanToDecimalConverter

open System
open FSharp.Core
open Xunit
open RomanConvertApp.RomanToDecimalConverter

[<Theory>]
[<InlineData("M0")>]
[<InlineData("C1")>]
[<InlineData("D2")>]
[<InlineData("L3")>]
[<InlineData("X4")>]
[<InlineData("V5")>]
[<InlineData("I6")>]
[<InlineData("I7V")>]
[<InlineData("8IV")>]
[<InlineData("IV9")>]
let ``romanToDecimalValue_ShouldThrowException_WhenInputContainsInvalidDigit`` (invalidInput: string) =
    // Act & Assert
    Assert.Throws<InvalidOperationException>(fun () -> romanToDecimalValue(invalidInput) |> ignore)

[<Theory>]
[<InlineData("A")>]
[<InlineData("B")>]
[<InlineData("E")>]
[<InlineData("F")>]
[<InlineData("H")>]
[<InlineData("J")>]
[<InlineData("K")>]
[<InlineData("N")>]
[<InlineData("O")>]
[<InlineData("P")>]
[<InlineData("Q")>]
[<InlineData("R")>]
[<InlineData("S")>]
[<InlineData("T")>]
[<InlineData("U")>]
[<InlineData("W")>]
[<InlineData("Y")>]
[<InlineData("Z")>]
[<InlineData("AXX")>]
[<InlineData("XAX")>]
[<InlineData("XXA")>]
let ``romanToDecimalValue_ShouldThrowException_WhenInputContainsInvalidLetter`` (invalidInput: string) = 
    // Act & Assert
    Assert.Throws<InvalidOperationException>(fun () -> romanToDecimalValue(invalidInput) |> ignore)

[<Theory>]
[<InlineData("I", 1)>]
[<InlineData("IV", 4)>]
[<InlineData("V", 5)>]
[<InlineData("IX", 9)>]
[<InlineData("X", 10)>]
[<InlineData("XL", 40)>]
[<InlineData("L", 50)>]
[<InlineData("XC", 90)>]
[<InlineData("C", 100)>]
[<InlineData("CD", 400)>]
[<InlineData("D", 500)>]
[<InlineData("CM", 900)>]
[<InlineData("M", 1000)>]
let ``romanToDecimalValue_ShouldReturnCorrectValue_WhenInputIsValidSBaseRomanNumeral`` (input: string, expected: int) =
    // Act
    let actual = romanToDecimalValue(input)

    // Assert
    Assert.Equal(expected, actual)
