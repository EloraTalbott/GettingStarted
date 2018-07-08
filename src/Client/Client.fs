module Client

open Elmish
open Elmish.React

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Fetch

open Shared

open Fulma


// type Model = Counter option

// type Msg =
// | Increment
// | Decrement
// | Init of Result<Counter, exn>



// let init () : Model * Cmd<Msg> =
//     let model = None
//     let cmd =
//         Cmd.ofPromise
//             (fetchAs<int> "/api/init")
//             []
//             (Ok >> Init)
//             (Error >> Init)
//     model, cmd

// let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
//     let model' =
//         match model,  msg with
//         | Some x, Increment -> Some (x + 1)
//         | Some x, Decrement -> Some (x - 1)
//         | None, Init (Ok x) -> Some x
//         | _ -> None
//     model', Cmd.none

// let safeComponents =
//     let intersperse sep ls =
//         List.foldBack (fun x -> function
//             | [] -> [x]
//             | xs -> x::sep::xs) ls []

//     let components =
//         [
//             "Saturn", "https://saturnframework.github.io/docs/"
//             "Fable", "http://fable.io"
//             "Elmish", "https://elmish.github.io/elmish/"
//             "Fulma", "https://mangelmaxime.github.io/Fulma"
//         ]
//         |> List.map (fun (desc,link) -> a [ Href link ] [ str desc ] )
//         |> intersperse (str ", ")
//         |> span [ ]

//     p [ ]
//         [ strong [] [ str "SAFE Template" ]
//           str " powered by: "
//           components ]

// let show = function
// | Some x -> string x
// | None -> "Loading..."

// let button txt onClick =
//     Button.button
//         [ Button.IsFullWidth
//           Button.Color IsPrimary
//           Button.OnClick onClick ]
//         [ str txt ]

// let multiply () = 
// //   Fable.Import.Browser.window.alert "Hello"
//   let rnd = System.Random()
//   let a = rnd.Next(10) * 10
//   let b = rnd.Next(10) * 10
//   let answer = Fable.Import.Browser.window.prompt("What is " + a.ToString() + " x " + b.ToString() + "?")
//   if ((int)answer = a * b) then
//     Fable.Import.Browser.window.alert("Correct!");
//   else
//     Fable.Import.Browser.window.alert("Try again silly! It is "+ (a * b).ToString() + "!");


// let view (model : Model) (dispatch : Msg -> unit) =
//     div []
//         [  ]


// #if DEBUG
// open Elmish.Debug
// open Elmish.HMR
// #endif

// Program.mkProgram init update view
// #if DEBUG
// |> Program.withConsoleTrace
// |> Program.withHMR
// #endif
// |> Program.withReact "elmish-app"
// #if DEBUG
// |> Program.withDebugger
// #endif
// |> Program.run


open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

// let init() =
//     let canvas = Browser.document.getElementsByTagName_canvas().[0]
//     canvas.width <- 1000.
//     canvas.height <- 800.
//     let ctx = canvas.getContext_2d()
//     // The (!^) operator checks and casts a value to an Erased Union type
//     // See http://fable.io/docs/interacting.html#Erase-attribute
//     ctx.fillStyle <- !^"rgb(200,0,0)"
//     ctx.fillRect (10., 10., 55., 50.)
//     ctx.fillStyle <- !^"rgba(0, 0, 200, 0.5)"
//     ctx.fillRect (30., 30., 55., 50.)

// init()


let changeColorFn () =
  let colors = ["red"; "green"; "blue"; "yellow";"purple";"black";"orange";"pink";]
  let changeColor () =
    let rnd = System.Random()
    let n = rnd.Next(colors.Length)
    // let newButton = Fable.Import.Browser.document.createElement("button")
    let mainDiv = Fable.Import.Browser.document.getElementById("elmish-app")
    // mainDiv.appendChild newButton |> ignore
    // newButton.innerText <- "foo"
    // newButton.style.backgroundColor <- "red"
    let mainBody = Fable.Import.Browser.document.getElementById("body")
    mainBody.style.backgroundColor <- colors.[n]
  let timer = Fable.Import.Browser.window.setInterval(changeColor, 500)
  timer |> ignore

changeColorFn ()