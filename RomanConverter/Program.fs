namespace RomanConverterApp

open RomanConvertApp

open Avalonia
open Avalonia.Themes.Fluent
open Elmish
open Avalonia.FuncUI.Hosts
open Avalonia.FuncUI.Elmish
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Controls

type MainWindow() as this =
    inherit HostWindow()
    do
        base.Title <- "Roman Converter App"
        base.Height <- 250.0
        base.MinHeight <- 250.0
        base.Width <- 400.0
        base.MinWidth <- 400.0
        base.WindowStartupLocation <- WindowStartupLocation.CenterScreen
        
        Elmish.Program.mkSimple RomanConverter.init RomanConverter.update RomanConverter.view
        |> Program.withHost this
        #if DEBUG
        |> Program.withConsoleTrace
        #endif
        |> Program.run

type App() =
    inherit Application()

    override this.Initialize() =
        this.Styles.Add (FluentTheme())
        this.RequestedThemeVariant <- Styling.ThemeVariant.Dark

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- MainWindow()
        | _ -> ()

module Program =

    [<EntryPoint>]
    let main(args: string[]) =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .StartWithClassicDesktopLifetime(args)