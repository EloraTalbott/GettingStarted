module Client

open Elmish
open Elmish.React

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Fetch

open Shared

open Fulma
open Fable.Import


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
// //   Browser.window.alert "Hello"
//   let rnd = System.Random()
//   let a = rnd.Next(10) * 10
//   let b = rnd.Next(10) * 10
//   let answer = Browser.window.prompt("What is " + a.ToString() + " x " + b.ToString() + "?")
//   if ((int)answer = a * b) then
//     Browser.window.alert("Correct!");
//   else
//     Browser.window.alert("Try again silly! It is "+ (a * b).ToString() + "!");


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


// let changeColorFn () =
//   let colors = ["red"; "green"; "blue"; "yellow";"purple";"black";"orange";"pink";"brown";]
//   let changeColor () =
//     let rnd = System.Random()
//     let n = rnd.Next(colors.Length)
//     // let newButton = Browser.document.createElement("button")
//     // let mainDiv = Browser.document.getElementById("elmish-app")
//     // mainDiv.appendChild newButton |> ignore
//     // newButton.innerText <- "foo"
//     // newButton.style.backgroundColor <- "red"
//     let mainBody = Fable.Import.Browser.document.getElementById("body")
//     mainBody.style.backgroundColor <- colors.[n]
//   let timer = Fable.Import.Browser.window.setInterval(changeColor, 500)
//   timer |> ignore
// changeColorFn ()


// let game1 () =
//   let mainBody = Browser.document.getElementById("body")
//   // let ghost = Browser.Image.Create()
//   let ghost = Browser.document.createElement_img()
//   ghost.src <- "images/ghost.bmp"
//   ghost.onclick <- (fun _ -> ghost.style.display <- "none")
//   mainBody.appendChild ghost |> ignore

// game1 ()

let game2 () =
  let taunts = 
    [
      "Nice try"
      "too slow"
      "you'll never catch me"
      "I'm too fast for you"
      "Boo"
      "yawn..."
      "I could do this all day"
      "tired yet?"
      "ready to give up?"
    ]

  let mainBody = Browser.document.getElementById("body")
  let header = Browser.document.createElement_h1()
  header.innerText <- "Catch me if you can..."
  mainBody.appendChild header |> ignore
  let ghost = Browser.document.createElement_img()
  ghost.style.position <- "absolute"
  ghost.src <- "images/ghost.bmp"
  let mutable caught = 0
  let caughtMe _ = 
    caught <- 1
    ghost.style.display <- "none"
    header.innerHTML <- "Ahh you caught me!!!"

  let runAway () = 
    if caught = 0 then
      let rnd = System.Random()
      let n = rnd.Next(taunts.Length - 1)
      header.innerText <- taunts.[n]
      ghost.style.left <- sprintf "%ipx" (rnd.Next(650))
      ghost.style.top <- sprintf "%ipx" (rnd.Next(400))
  let runAwaySoon _ = Browser.window.setTimeout(runAway,200,[]) |> ignore 
  ghost.onmouseenter <- runAwaySoon
  ghost.onclick <- caughtMe
  mainBody.appendChild ghost |> ignore
  
game2 ()
