namespace RomanConvertApp

open Avalonia.FuncUI.DSL
open FSharp.Core
open Avalonia.Media
open DecimalToRomanConverter
open RomanToDecimalConverter

module RomanConverter =
    open Avalonia.Controls
    open Avalonia.Layout
    
    type State = { 
        romanNumber: string 
        decimalNumber: string
        errorStatus: string
    }

    let init() = { 
        romanNumber = ""
        decimalNumber = ""
        errorStatus = ""
    }

    type Msg =
    | SetRomanNumber of string
    | SetDecimalNumber of string
    | SetErrorStatus of string
    | Reset

    let update (msg: Msg) (state: State) : State = 
        match msg with
        | SetRomanNumber roman -> { state with romanNumber = roman }
        | SetDecimalNumber decimal -> { state with decimalNumber = decimal }
        | SetErrorStatus err -> { state with errorStatus = err }
        | Reset -> init()

    let view (state: State) (dispatch) =
        Grid.create [
            Grid.rowDefinitions "auto, auto, auto, auto"
            Grid.background "#2e2813"
            Grid.children [

                // Title
                TextBlock.create [
                    TextBlock.row 0
                    TextBlock.margin (8.0, 8.0, 8.0, 12.0)
                    TextBlock.text ("Roman Converter")
                    TextBlock.horizontalAlignment HorizontalAlignment.Center
                    TextBlock.verticalAlignment VerticalAlignment.Center
                    TextBlock.fontSize 20.0
                    TextBlock.fontWeight FontWeight.Bold
                ]

                // Roman number
                Grid.create [
                    Grid.row 1
                    Grid.columnDefinitions "auto, *, auto"
                    Grid.children [
                        TextBlock.create [
                            TextBlock.margin (5.0, 5.0, 11.0, 5.0)
                            TextBlock.column 0
                            TextBlock.text("Roman number")
                            TextBlock.verticalAlignment VerticalAlignment.Center
                        ]
                        TextBox.create [
                            TextBox.margin 5.0
                            TextBox.column 1
                            TextBox.text (state.romanNumber)
                            TextBox.onTextChanged (fun text -> text |> SetRomanNumber |> dispatch)
                        ] 
                        Button.create [
                            Button.margin 5.0
                            Button.column 2
                            Button.content "Convert"
                            Button.background Colors.Green
                            Button.onClick((fun _ -> 
                                "" |> SetDecimalNumber |> dispatch;
                                "" |> SetErrorStatus |> dispatch;
                                match romanToDecimal(state.romanNumber) with 
                                | Ok decimal ->
                                    decimal |> SetDecimalNumber |> dispatch
                                | Error err -> 
                                    err |> SetErrorStatus |> dispatch), SubPatchOptions.OnChangeOf state.romanNumber)
                        ]
                    ]
                ]

                // Decimal number
                Grid.create [
                    Grid.row 2
                    Grid.columnDefinitions "auto, *, auto"
                    Grid.children [
                        TextBlock.create [
                            TextBlock.margin 5.0
                            TextBlock.column 0
                            TextBlock.text("Decimal number")
                            TextBlock.verticalAlignment VerticalAlignment.Center
                        ]
                        TextBox.create [
                            TextBox.margin 5.0
                            TextBox.column 1
                            TextBox.text (state.decimalNumber)
                            TextBox.onTextChanged (fun text -> text |> SetDecimalNumber |> dispatch)
                        ] 
                        Button.create [
                            Button.margin 5.0
                            Button.column 2
                            Button.content "Convert"
                            Button.background Colors.Green
                            Button.onClick(
                                (fun _ -> 
                                    "" |> SetRomanNumber |> dispatch;
                                    "" |> SetErrorStatus |> dispatch;
                                    match decimalToRoman(state.decimalNumber) with
                                    | Ok roman -> 
                                        roman |> SetRomanNumber |> dispatch
                                    | Error err -> 
                                        err |> SetErrorStatus |> dispatch
                                ), 
                                SubPatchOptions.OnChangeOf state.decimalNumber)
                       ]
                    ]
                ]

                Grid.create [
                    Grid.row 3
                    Grid.columnDefinitions "*, *, auto"
                    Grid.children [
                        TextBlock.create [
                            Grid.column 1
                            TextBlock.width 242.0
                            TextBlock.margin 5.0
                            TextBlock.textWrapping TextWrapping.Wrap
                            TextBlock.foreground Colors.Red
                            TextBlock.verticalAlignment VerticalAlignment.Center
                            TextBlock.text (state.errorStatus)
                        ]
                        Button.create [
                            Button.margin 5.0
                            Button.column 2
                            Button.padding (15.0, 5.0, 15.0, 5.0)
                            Button.content "Reset"
                            Button.onClick (fun _ -> dispatch Reset)
                        ]
                    ]
                ]
            ]
        ] 