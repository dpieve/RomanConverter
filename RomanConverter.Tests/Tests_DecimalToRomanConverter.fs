module Tests_DecimalToRomanConverter

open System
open FSharp.Core
open Xunit
open RomanConvertApp.DecimalToRomanConverter

[<Theory>]
[<InlineData(1, "I")>]
[<InlineData(4, "IV")>]
[<InlineData(5, "V")>]
[<InlineData(9, "IX")>]
[<InlineData(10, "X")>]
[<InlineData(40, "XL")>]
[<InlineData(50, "L")>]
[<InlineData(90, "XC")>]
[<InlineData(100, "C")>]
[<InlineData(400, "CD")>]
[<InlineData(500, "D")>]
[<InlineData(900, "CM")>]
[<InlineData(1000, "M")>]
let ``decimalToRomanValue_ShouldReturnCorrectValue_WhenInputIsValid`` (input: int, expected: string) =
    // Act
    let actual = decimalToRomanValue input

    // Assert
    Assert.Equal(expected, actual)

