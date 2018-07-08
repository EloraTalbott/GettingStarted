module Client

open Elmish
open Elmish.React

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Fetch

open Shared

open Fulma


type Model = Counter option

type Msg =
| Increment
| Decrement
| Init of Result<Counter, exn>



let init () : Model * Cmd<Msg> =
    let model = None
    let cmd =
        Cmd.ofPromise
            (fetchAs<int> "/api/init")
            []
            (Ok >> Init)
            (Error >> Init)
    model, cmd

let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    let model' =
        match model,  msg with
        | Some x, Increment -> Some (x + 1)
        | Some x, Decrement -> Some (x - 1)
        | None, Init (Ok x) -> Some x
        | _ -> None
    model', Cmd.none

let safeComponents =
    let intersperse sep ls =
        List.foldBack (fun x -> function
            | [] -> [x]
            | xs -> x::sep::xs) ls []

    let components =
        [
            "Saturn", "https://saturnframework.github.io/docs/"
            "Fable", "http://fable.io"
            "Elmish", "https://elmish.github.io/elmish/"
            "Fulma", "https://mangelmaxime.github.io/Fulma"
        ]
        |> List.map (fun (desc,link) -> a [ Href link ] [ str desc ] )
        |> intersperse (str ", ")
        |> span [ ]

    p [ ]
        [ strong [] [ str "SAFE Template" ]
          str " powered by: "
          components ]

let show = function
| Some x -> string x
| None -> "Loading..."

let button txt onClick =
    Button.button
        [ Button.IsFullWidth
          Button.Color IsPrimary
          Button.OnClick onClick ]
        [ str txt ]

let multiply = 
//   Fable.Import.Browser.window.alert "Hello"
  let rnd = System.Random()
  let a = rnd.Next(10) * 10
  let b = rnd.Next(10) * 10
  let answer = Fable.Import.Browser.window.prompt("What is " + a.ToString() + " x " + b.ToString() + "?")
  if ((int)answer = a * b) then
    Fable.Import.Browser.window.alert("Correct!");
  else
    Fable.Import.Browser.window.alert("Try again silly! It is "+ (a * b).ToString() + "!");

let view (model : Model) (dispatch : Msg -> unit) =
    div []
        [  ]


#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
