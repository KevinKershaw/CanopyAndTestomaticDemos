﻿module testomatic.teeReporter
open canopy.reporters
open System.Collections.Generic

type IReporterEx =
    abstract member objective : string -> unit
    abstract member precondition : string -> unit
    abstract member postcondition : string -> unit

type TeeReporter () =
    let _reporters = new List<IReporter>()

    member this.Add (r : IReporter) =
        _reporters.Add r

    interface IReporter with               
        member this.pass () =
            _reporters.ForEach (fun i -> i.pass ())

        member this.fail ex id ss =
            _reporters.ForEach (fun i -> i.fail ex id ss)

        member this.describe d = 
            _reporters.ForEach (fun i -> i.describe d)
          
        member this.contextStart c = 
            _reporters.ForEach (fun i -> i.contextStart c)

        member this.contextEnd c = 
            _reporters.ForEach (fun i -> i.contextEnd c)

        member this.summary minutes seconds passed failed =  
            _reporters.ForEach (fun i -> i.summary minutes seconds passed failed)
        
        member this.write w = 
            _reporters.ForEach (fun i -> i.write w)
        
        member this.suggestSelectors selector suggestions = 
            _reporters.ForEach (fun i -> i.suggestSelectors selector suggestions)

        member this.testStart id = 
            _reporters.ForEach (fun i -> i.testStart id)
            
        member this.testEnd id = 
            _reporters.ForEach (fun i -> i.testEnd id)

        member this.quit () = 
            _reporters.ForEach (fun i -> i.quit ())
        
        member this.suiteBegin () = 
            _reporters.ForEach (fun i -> i.suiteBegin ())

        member this.suiteEnd () = 
            _reporters.ForEach (fun i -> i.suiteEnd ())

        member this.coverage url ss = 
            _reporters.ForEach (fun i -> i.coverage url ss)

        member this.todo () = 
            _reporters.ForEach (fun i -> i.todo ())

        member this.skip () = 
            _reporters.ForEach (fun i -> i.skip ())

    interface IReporterEx with               
        member this.objective s =
            _reporters.ForEach (fun i -> 
                match box i with
                | :? IReporterEx as rx -> rx.objective s
                | _ -> ()
                )

        member this.precondition s =
            _reporters.ForEach (fun i -> 
                match box i with
                | :? IReporterEx as rx -> rx.precondition s
                | _ -> ()
                )

        member this.postcondition s =
            _reporters.ForEach (fun i -> 
                match box i with
                | :? IReporterEx as rx -> rx.postcondition s
                | _ -> ()
                )
