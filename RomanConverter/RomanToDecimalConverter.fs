namespace RomanConvertApp

type Result =
    | Success of string
    | Error of string

module RomanToDecimalConverter =
    let romanToDecimalValue roman : int =
        let rec loop roman result = 
            match roman with
            | "" -> result
            | _ when roman.StartsWith("M") -> loop (roman.Substring(1)) (result + 1000)
            | _ when roman.StartsWith("CM") -> loop (roman.Substring(2)) (result + 900)
            | _ when roman.StartsWith("D") -> loop (roman.Substring(1)) (result + 500)
            | _ when roman.StartsWith("CD") -> loop (roman.Substring(2)) (result + 400)
            | _ when roman.StartsWith("C") -> loop (roman.Substring(1)) (result + 100)
            | _ when roman.StartsWith("XC") -> loop (roman.Substring(2)) (result + 90)
            | _ when roman.StartsWith("L") -> loop (roman.Substring(1)) (result + 50)
            | _ when roman.StartsWith("XL") -> loop (roman.Substring(2)) (result + 40)
            | _ when roman.StartsWith("X") -> loop (roman.Substring(1)) (result + 10)
            | _ when roman.StartsWith("IX") -> loop (roman.Substring(2)) (result + 9)
            | _ when roman.StartsWith("V") -> loop (roman.Substring(1)) (result + 5)
            | _ when roman.StartsWith("IV") -> loop (roman.Substring(2)) (result + 4)
            | _ when roman.StartsWith("I") -> loop (roman.Substring(1)) (result + 1)
            | _ -> invalidOp "Error - Invalid input"
        loop roman 0
       
    let romanToDecimal (roman: string) : Result<string, string> =
        try 
            let decimal = romanToDecimalValue(roman)
            if decimal > 0 && decimal < 4000 then
                Result<string, string>.Ok(decimal.ToString())
            else
                Result<string, string>.Error("Error - Roman number must be between I and MMMCMXCIX")
        with 
            | ex -> 
                Result<string, string>.Error("Error - Invalid input")
