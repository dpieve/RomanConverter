namespace RomanConvertApp

module DecimalToRomanConverter =
    let decimalToRomanValue decimal : string =
        let rec loop decimal result =
            match decimal with
            | 0 -> result
            | _ when decimal >= 1000 -> loop (decimal - 1000) (result + "M")
            | _ when decimal >= 900 -> loop (decimal - 900) (result + "CM")
            | _ when decimal >= 500 -> loop (decimal - 500) (result + "D")
            | _ when decimal >= 400 -> loop (decimal - 400) (result + "CD")
            | _ when decimal >= 100 -> loop (decimal - 100) (result + "C")
            | _ when decimal >= 90 -> loop (decimal - 90) (result + "XC")
            | _ when decimal >= 50 -> loop (decimal - 50) (result + "L")
            | _ when decimal >= 40 -> loop (decimal - 40) (result + "XL")
            | _ when decimal >= 10 -> loop (decimal - 10) (result + "X")
            | _ when decimal >= 9 -> loop (decimal - 9) (result + "IX")
            | _ when decimal >= 5 -> loop (decimal - 5) (result + "V")
            | _ when decimal >= 4 -> loop (decimal - 4) (result + "IV")
            | _ -> loop (decimal - 1) (result + "I")
        loop decimal ""

    let decimalToRoman (decimal: string) : Result<string, string> =
        try
            match System.Int32.TryParse(decimal) with
                
                | (true, value) when value > 0 && value < 4000 -> 
                    Result<string, string>.Ok(decimalToRomanValue(value))
                
                | (true, _) -> 
                    Result<string, string>.Error("Error - Decimal number must be between 1 and 3999")
                
                | (false, _) -> 
                    Result<string, string>.Error("Error - Invalid input")
        with
            | ex ->
                Result<string, string>.Error("Error - An error occurred")