module logFileReporter
open canopy
open reporters
open System

type LogFileReporter (logFileName : string) =
    
    let openOutputStream () =
        let outputFileInfo = new IO.FileInfo (logFileName)
        if not (System.IO.Directory.Exists (outputFileInfo.Directory.FullName)) then
            System.IO.Directory.CreateDirectory (outputFileInfo.Directory.FullName) |> ignore
        new System.IO.StreamWriter (outputFileInfo.FullName)

    let tw = openOutputStream ()

    interface IReporter with               
        member this.pass () = tw.WriteLine " PASSED"

        member this.fail ex id ss =
            tw.WriteLine " FAILED"
            tw.WriteLine ("    " + ex.Message)
            tw.WriteLine "    stack:"
            ex.StackTrace.Split([| "\r\n"; "\n" |], StringSplitOptions.None)
            |> Array.iter (fun trace -> 
                if trace.Contains(".FSharp.") || trace.Contains("canopy.core") || trace.Contains("OpenQA.Selenium") 
                    || trace.Contains("canopy.runner") then
                    ()
                else
                    tw.WriteLine ("    " + trace)
                )

        member this.describe d = tw.WriteLine d
          
        member this.contextStart c = tw.WriteLine ("context \"" + c + "\"")

        member this.contextEnd c = ()

        member this.summary minutes seconds passed failed =
            tw.WriteLine ()
            tw.WriteLine ("{0} minutes {1} seconds to execute", minutes, seconds)
            tw.WriteLine ("{0} passed", passed)
            tw.WriteLine ("{0} failed", failed)
        
        member this.write w = tw.WriteLine ("    " + w)
        
        member this.suggestSelectors selector suggestions = ()

        member this.testStart id = tw.Write ("test \"" + id + "\"")
            
        member this.testEnd id = ()

        member this.quit () =
            tw.Close ()
            tw.Dispose ()
        
        member this.suiteBegin () = ()

        member this.suiteEnd () = ()

        member this.coverage url ss = ()

        member this.todo () = ()

        member this.skip () = ()
