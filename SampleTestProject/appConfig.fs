module appConfig
open FSharp.Configuration
open canopy.configuration
open System

type AppConfig = YamlConfig<"config.yaml">
let config = AppConfig()
config.Load ".\config.yaml"

let baseUrl = config.baseUrl.ToString()

chromeDir <- (AppDomain.CurrentDomain.BaseDirectory + @"\BrowserSupport")
ieDir <- (AppDomain.CurrentDomain.BaseDirectory + @"\BrowserSupport")
